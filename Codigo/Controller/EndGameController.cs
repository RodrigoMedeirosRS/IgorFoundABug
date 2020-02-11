using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Controller;
using IgorFoundABug.Codigo.Model.BLL;

namespace IgorFoundABug.Codigo.Controller
{
    public class EndGameController : Label
    {
        private List<string> texto = new List<string>();
		private JogadorController jogador;
		private int textoatual = 0;
		private GameController Base;
        private Node devs;
		private Timer Tempo;
		public override void _Ready()
		{
			Tempo = GetChild<Timer>(0);
            devs = GetParent().GetParent().GetNode("./Objetos");
			Base = GetNode("/root/Base") as GameController;
			jogador = GetParent().GetNode("./Igor") as JogadorController;
			jogador.personagemDTO.Municao = 99999;
            jogador.paused = true;
			if (Base.Portugues)
				Portugues();
			else
				Ingles();
			Text = texto[textoatual];
		}
		private void Portugues()
		{
			texto.Add("Igor: Então!");
			texto.Add("Igor: Vocês pensaram");
			texto.Add("Igor: que eu queria fugir?");
			texto.Add("Igor: Nãããããão!");
			texto.Add("Igor: Aqui eu sou invencível!");
			texto.Add("Igor: O rei dos bugs!");
            texto.Add("Igor: Agora chegou a");
            texto.Add("Igor: hora de vocês");
            texto.Add("Igor: Muhuauahua");
		}
		private void Ingles()
		{
			texto.Add("Igor: So!");
			texto.Add("Igor: Did you belive");
			texto.Add("Igor: i want flee?");
			texto.Add("Igor: Nooooooo!");
			texto.Add("Igor: Here i am");
			texto.Add("Igor: Invencible");
			texto.Add("Igor: The King of Bugs!");
            texto.Add("Igor: Now it's time");
            texto.Add("Igor: for revenge!");
            texto.Add("Igor: Muhuauahua");
		}
		private void _on_Timer_timeout()
		{
			PulaTexto();
		}
		public override void _Process(float delta)
		{
			if (devs.GetChildCount() <= 0)
			{
                BugsBLL.Vida = 0;
				Base.MudaNivel(0);
			}
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
