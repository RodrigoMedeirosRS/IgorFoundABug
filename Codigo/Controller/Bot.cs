using Godot;
using System;
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
			personagemDTO.AnimationPlaryer = GetChild<AnimationPlayer>(4);
			SensorDireito = GetChild(1).GetChild<RayCast2D>(0);
			SensorEsquerdo = GetChild(1).GetChild<RayCast2D>(1);
			TimerDireita = GetChild(1).GetChild<Timer>(2);
			TimerEsquerda = GetChild(1).GetChild<Timer>(3);
			ArmaDireita = GetChild(2).GetChild(0) as ArmaController;
			ArmaEquerda = GetChild(2).GetChild(1) as ArmaController;
			GetChild<CollisionShape2D>(0).Disabled = false;
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
		}
		private void Animar()
		{
			if(personagemDTO.Vivo)
			{

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
				GetChild<CollisionShape2D>(0).Disabled = true;
				TimerDireita.Stop();
				TimerEsquerda.Stop();
			}
		}
	}
}
