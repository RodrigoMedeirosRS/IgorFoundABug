using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Controller;

namespace IgorFoundABug.Codigo.Model.BLL
{
	public class IntroBLL : Label
	{
		private List<string> texto = new List<string>();
		private JogadorController jogador;
		private int textoatual = 0;
		public override void _Ready()
		{
			jogador = GetParent().GetNode("./Igor") as JogadorController;
			jogador.paused = true;
			texto.Add("Ola Igor");
			texto.Add("Bem vindo a sua prisão");
			texto.Add("Nós os programadores");
			texto.Add("Ficamos com raiva de você");
			texto.Add("Por causa de todos os bugs");
			texto.Add("Que você achou nos");
			texto.Add("nossos códigos");
			texto.Add("Por isso te prendemos");
			texto.Add("Em um jogo de Nokia");
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
			texto.Add("Dica: Encontre um bug");
			Text = texto[textoatual];
		}
		private void _on_Timer_timeout()
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
		public override void _Process(float delta)
		{
			if (BugsBLL.FlyBug)
			{
				Text = "Igor: Ahá!";
			}
		}
	}
}
