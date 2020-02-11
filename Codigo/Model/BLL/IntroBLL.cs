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
		public override void _Ready()
		{
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
			texto.Add("Ola Igor");
			texto.Add("Bem vindo a sua prisão");
			texto.Add("Nós os programadores");
			texto.Add("Ficamos com raiva de você");
			texto.Add("Por causa de todos os bugs");
			texto.Add("Que você achou nos");
			texto.Add("nossos códigos");
			texto.Add("Por isso te prendemos");
			texto.Add("Em um jogo de Nokia 3310");
			texto.Add("Impossível de vencer");
			texto.Add("Aproveite sua prisão");
			texto.Add("Pois você ficará aqui");
			texto.Add("para sempre!");
			texto.Add("Muahahahahahahahaha!");
			texto.Add("Igor: Não!");
			texto.Add("Igor: Eu conheço vocês");
			texto.Add("Igor: Esse jogo deve");
			texto.Add("Igor: ter bugs!");
			texto.Add("Igor: Eu vou encontrar");
			texto.Add("Igor: e usá-los para");
			texto.Add("Igor: vencer!");
			texto.Add("Dica: Morrer irá forçar");
			texto.Add("Dica: o jogo.");
			texto.Add("Dica: Provocando Bugs.");
			texto.Add("Dica: Logo morrer pode");
			texto.Add("Dica: Não ser algo ruim");
			texto.Add("Dica: Tente morrer");
			texto.Add("Dica: De formas diferentes");
			texto.Add("Dica: Para encontrar");
			texto.Add("Dica: bugs.");
			texto.Add("Mexa-se para encontrar um bug");
		}
		private void Ingles()
		{
			texto.Add("Hello Igor");
			texto.Add("Wellcome to your prision");
			texto.Add("We the programmers");
			texto.Add("We get mad at you");
			texto.Add("Because of all the bugs");
			texto.Add("That you found in");
			texto.Add("in our codes");
			texto.Add("That's why we arrested you");
			texto.Add("In a Nokia 3310 game");
			texto.Add("Impossible to win");
			texto.Add("Enjoy your prision");
			texto.Add("Because you will stay here");
			texto.Add("forever!");
			texto.Add("Muahahahahahahahaha!");
			texto.Add("Igor: No!");
			texto.Add("Igor: I know you");
			texto.Add("Igor: This game ");
			texto.Add("Igor: must have bugs!");
			texto.Add("Igor: I will find");
			texto.Add("Igor: and use them to win!");
			texto.Add("Tip: Death can force");
			texto.Add("Tip: a bug.");
			texto.Add("Tip: So Daying");
			texto.Add("Tip: Don't be a bad thing");
			texto.Add("Tip: Try kill yourself");
			texto.Add("Tip: In different ways");
			texto.Add("Tip: To find");
			texto.Add("Tip: bugs.");
			texto.Add("Move yourself quickly to bug");
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
					textoatual += 1;
				}
				if (textoatual == texto.Count)
					jogador.paused = false;
			}
		}
	}
}
