using Godot;
using System;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Controller
{
	public class Bot : KinematicBody2D
	{
		PersonagemDTO BotDTO = new PersonagemDTO();
		private ArmaController ArmaDireita;
		private ArmaController ArmaEquerda;
		private RayCast2D SensorDireito;
		private RayCast2D SensorEsquerdo;
		private Timer TimerDireita;
		private Timer TimerEsquerda;
		public override void _Ready()
		{
			BotDTO.Vivo = true;
			BotDTO.Velocidade = 0.3f;
			BotDTO.Peso = 80;
			BotDTO.Gravidade = 9.8f;
			BotDTO.ForcaPulo = -20;
			BotDTO.Direcao = new Vector2(0,0);
			BotDTO.Corpo2D = this;
			BotDTO.UltimaAnimcacao = "";
			BotDTO.AnimationPlaryer = GetChild<AnimationPlayer>(4);
			SensorDireito = GetChild(1).GetChild<RayCast2D>(0);
			SensorEsquerdo = GetChild(1).GetChild<RayCast2D>(1);
			TimerDireita = GetChild(1).GetChild<Timer>(2);
			TimerEsquerda = GetChild(1).GetChild<Timer>(3);
			ArmaDireita = GetChild(2).GetChild(0) as ArmaController;
			ArmaEquerda = GetChild(2).GetChild(1) as ArmaController;
		}
		public override void _PhysicsProcess(float delta)
		{
			GravidadeBLL.Gravidade2D(BotDTO);
			Acoes();
		}
		private void Acoes()
		{
			if (BotDTO.Vivo)
				Movimento();
			Animar();
		}
		private void Movimento()
		{
			var distanciaDireita = SensorBLL.Detectar(SensorDireito, "player");
			if (distanciaDireita != null)
			{
				if (distanciaDireita < 30)
				{
					if (TimerDireita.IsStopped()) 
						TimerDireita.Start();
					BotDTO.Direcao = new Vector2(-1, 0);
					MovimentoKinematicoBLL.Move2D(BotDTO);
					return;
				}
			}
			
			var distanciaEsquerda = SensorBLL.Detectar(SensorEsquerdo, "player");
			if (distanciaEsquerda !=null)
			{
				if (TimerEsquerda.IsStopped()) 
					TimerEsquerda.Start();
				BotDTO.Direcao = new Vector2(1, 0);
				MovimentoKinematicoBLL.Move2D(BotDTO);
				return;
			}
		}
		private void Animar()
		{

		}
		private void _on_TimerDireita_timeout()
		{
			ArmaDireita.Atirar(BotDTO, false);
		}
		private void _on_TimerEsquerda_timeout()
		{
			ArmaEquerda.Atirar(BotDTO, true);
		}
	}
}
