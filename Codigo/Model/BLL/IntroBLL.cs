using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Controller;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Model.BLL
{
	public class IntroBLL : Label
	{
		private List<string> texto = new List<string>();
		private JogadorController jogador;
		private int textoatual = 0;
		private GameController Base;
		private Timer Tempo;
		public override void _Ready()
		{
			Tempo = GetChild<Timer>(0);
			Base = GetNode("/root/Base") as GameController;
			jogador = GetParent().GetNode("./Igor") as JogadorController;
			jogador.paused = true;
			if (Base.Portugues)
				Portugues();
			else
				Ingles();
			Text = texto[textoatual];
		}
		private void Portugues()
		{
			texto.Add("Ola Igor!");
			texto.Add("Bem vindo a sua prisão!");
			texto.Add("Nós os programadores");
			texto.Add("ficamos com raiva de você");
			texto.Add("por causa de todos os bugs");
			texto.Add("que você achou nos nossos códigos.");
			texto.Add("Por isso te prendemos");
			texto.Add("Em um jogo de celular");
			texto.Add("impossível de vencer!");
			texto.Add("Aproveite sua prisão!");
			texto.Add("Pois você ficará aqui");
			texto.Add("Para todo o sempre!");
			texto.Add("Muahahahahahahahaha!");
			texto.Add("Igor: Não!");
			texto.Add("Igor: Eu conheço vocês!");
			texto.Add("Igor: Esse jogo deve ter bugs!");
			texto.Add("Igor: Eu vou encontrar todos");
			texto.Add("Igor: e usá-los para vencer!");
			texto.Add("Dica: Morrer provocará Bugs.");
			texto.Add("Dica: Logo morrer não é algo ruim.");
			texto.Add("Dica: Tente morrer");
			texto.Add("Dica: Para encontrar bugs.");
			texto.Add("Mexa-se para encontrar um bug");
		}
		private void Ingles()
		{
			texto.Add("Hello Igor");
			texto.Add("wellcome to your prision!");
			texto.Add("We the programmers");
			texto.Add("get mad with you,");
			texto.Add("because all the bugs");
			texto.Add("you found in our codes.");
			texto.Add("So we arrested you");
			texto.Add("into a old phone game");
			texto.Add("impossible to win.");
			texto.Add("Enjoy your prision");
			texto.Add("because you will stay here");
			texto.Add("forever and ever!");
			texto.Add("Muahahahahahahahaha!");
			texto.Add("Igor: No!");
			texto.Add("Igor: I know you!");
			texto.Add("Igor: This game must have bugs!");
			texto.Add("Igor: I will find and use");
			texto.Add("Igor: them to win!");
			texto.Add("Tip: Death can force a bug.");
			texto.Add("Tip: So Daying  don't be");
			texto.Add("Tip: a bad thing");
			texto.Add("Tip: Try kill yourself");
			texto.Add("Tip: To find bugs.");
			texto.Add("Move quickly to find a bug");
		}
		private void _on_Timer_timeout()
		{
			PulaTexto();	
		}
		public override void _PhysicsProcess(float delta)
		{
			if(KeyboardUtils.GetKey("ui_select", Keystatus.Pressed))
			
				PulaTexto();
		}
		private void PulaTexto()
		{
			if (textoatual < texto.Count)
			{
				if (BugsBLL.FlyBug == false)
				{
					Text = texto[textoatual];
					Tempo.WaitTime = 3;
					textoatual += 1;
				}
				if (textoatual == texto.Count)
					jogador.paused = false;
			}
		}
	}
}
