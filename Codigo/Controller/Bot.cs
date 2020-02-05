using Godot;
using System;
using System.Collections.Generic;
using IgorFoundABug.Codigo.View;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Controller
{
	public class Bot : KinematicBody2D
	{
		public PersonagemDTO personagemDTO = new PersonagemDTO();
		private ArmaController ArmaDireita;
		private ArmaController ArmaEquerda;
		private RayCast2D SensorDireito;
		private RayCast2D SensorEsquerdo;
		private Timer TimerDireita;
		private Timer TimerEsquerda;
		private List<Node> PowerUP;
		public override void _Ready()
		{
			personagemDTO.Vivo = true;
			personagemDTO.Velocidade = 0.3f;
			personagemDTO.Peso = 80;
			personagemDTO.Gravidade = 9.8f;
			personagemDTO.ForcaPulo = -20;
			personagemDTO.Direcao = new Vector2(0,0);
			personagemDTO.Corpo2D = this;
			personagemDTO.UltimaAnimcacao = "";
			personagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
			SensorDireito = GetNode<RayCast2D>("./Sensores/Direita");
			SensorEsquerdo = GetNode<RayCast2D>("./Sensores/Esquerda");
			TimerDireita = GetNode<Timer>("./Sensores/TimerDireita");
			TimerEsquerda = GetNode<Timer>("./Sensores/TimerEsquerda");
			ArmaDireita = GetNode<Node>("./Armas/ArmaDireita") as ArmaController;
			ArmaEquerda = GetNode<Node>("./Armas/ArmaEsquerda") as ArmaController;
			PowerUP = ObjectPoolingBLL.criarPool(GetParent().GetParent().GetNode<Node>("./Spawners"), "res://Cenas/Objetos/PowerUP.tscn", 1);
			GetNode<CollisionShape2D>("./Corpo").Disabled = false;
		}
		public override void _PhysicsProcess(float delta)
		{
			Acoes();
		}
		private void Acoes()
		{
			if (personagemDTO.Vivo)
				Movimento();
			Animar();
		}
		private void Movimento()
		{
			GravidadeBLL.Gravidade2D(personagemDTO);
			var distanciaDireita = SensorBLL.Detectar(SensorDireito, "player");
			if (distanciaDireita != null)
			{
				if (TimerDireita.IsStopped()) 
					TimerDireita.Start();
				if (distanciaDireita < 30)
				{
					personagemDTO.Direcao = new Vector2(-1, 0);
					MovimentoKinematicoBLL.Move2D(personagemDTO);
					return;
				}
			}
			
			var distanciaEsquerda = SensorBLL.Detectar(SensorEsquerdo, "player");
			if (distanciaEsquerda !=null)
			{
				if (TimerEsquerda.IsStopped()) 
					TimerEsquerda.Start();
				if (distanciaEsquerda < 30)
				{
					personagemDTO.Direcao = new Vector2(1, 0);
					MovimentoKinematicoBLL.Move2D(personagemDTO);
					return;
				}
			}
			personagemDTO.Direcao = new Vector2(0, 0);
		}
		private void Animar()
		{
			if (personagemDTO.Vivo && personagemDTO.AnimationPlayer.CurrentAnimation != "Hit")
			{
				AnimationView.ExecutarAnimacao(personagemDTO.Direcao == new Vector2(0,0), "Idle", personagemDTO);
				AnimationView.ExecutarAnimacao(personagemDTO.Direcao != new Vector2(0,0), "Walk", personagemDTO);
			}
			AnimationView.ExecutarAnimacao(!personagemDTO.Vivo, "Morte", personagemDTO);
		}
		private void _on_TimerDireita_timeout()
		{
			ArmaDireita.Atirar(personagemDTO, false);
		}
		private void _on_TimerEsquerda_timeout()
		{
			ArmaEquerda.Atirar(personagemDTO, true);
		}
		private void _on_AnimationPlayer_animation_started(String anim_name)
		{
			if (anim_name == "Morte")
			{
				GetNode<CollisionShape2D>("./Corpo").Disabled = true;
				TimerDireita.Stop();
				TimerEsquerda.Stop();
			}
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "Morte")
			{
				PowerUPController powerUP = (ObjectPoolingBLL.executarPooling(PowerUP) as PowerUPController);
				powerUP.Drop(GlobalPosition);
			}	
		}
		private void _on_SensorCabeca_body_entered(object body)
		{
			if(personagemDTO.Vivo)
			{
				if ((body as Node).IsInGroup("player"))
				{
					AnimationView.ExecutarAnimacao(personagemDTO.Vivo, "Hit", personagemDTO);
					(body as JogadorController).personagemDTO.Gravidade = (body as JogadorController).personagemDTO.ForcaPulo * 1.2f;
					ArmaDireita.Atirar(personagemDTO, false);
					ArmaEquerda.Atirar(personagemDTO, true);
				}
			}
		}

	}
}
