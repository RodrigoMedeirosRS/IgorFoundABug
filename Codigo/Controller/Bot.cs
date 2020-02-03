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
					BotDTO.Direcao = new Vector2(-1, 0);
					MovimentoKinematicoBLL.Move2D(BotDTO);
				}
			}
			
			var distanciaEsquerda = SensorBLL.Detectar(SensorEsquerdo, "player");
			if (distanciaEsquerda !=null)
			{
				BotDTO.Direcao = new Vector2(1, 0);
				MovimentoKinematicoBLL.Move2D(BotDTO);
			}
		}
		private void Animar()
		{

		}
	}
}

