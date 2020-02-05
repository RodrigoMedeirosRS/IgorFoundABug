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
		public override void _Ready()
		{
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
			texto.Add("Igor: Vocês acharam");
			texto.Add("Igor: que eu queria");
			texto.Add("Igor: fugir?");
			texto.Add("Igor: Nãããããão!");
			texto.Add("Igor: Aqui eu sou");
			texto.Add("Igor: invencível!");
            texto.Add("Igor: Chegou a");
            texto.Add("Igor: Hora de vocês");
            texto.Add("Igor: Muhuauahuauah");
		}
		private void Ingles()
		{
			texto.Add("Igor: So!");
			texto.Add("Igor: Did you belive");
			texto.Add("Igor: i want flee?");
			texto.Add("Igor: Nooooooo!");
			texto.Add("Igor: Here i am");
			texto.Add("Igor: Invencible");
			texto.Add("Igor: Now");
            texto.Add("Igor: Now it's time for");
            texto.Add("Igor: for revenge!");
            texto.Add("Igor: Muhuauahuauah");
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
			if (devs.GetChildCount() <= 0)
			{
                BugsBLL.Vida = 0;
				Base.MudaNivel(Base.NivelAtual = 0);
			}
		}
    }
}
