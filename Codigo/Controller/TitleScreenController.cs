using Godot;
using System;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
	public class TitleScreenController : Node2D
	{
		private Sprite TitleScreen;
		private Label Texto;
		private List<string> Abertura;
		private int TextoAtual;
		private GameController Base;
		public override void _Ready()
		{
			TextoAtual = 0;
			Abertura = new List<String>();
			Abertura.Add("Aviso: nenhum tester foi maltaradado ou ferido para a criaçao desse jogo.");
			Abertura.Add("Warning: no tester was malted or injured to create this game.");
			Abertura.Add("A Game By R.M.Lehnemann");
			Abertura.Add("");
			Texto = GetChild(0).GetChild<Label>(1);
			Texto.Text = Abertura[TextoAtual];
			Base = GetParent().GetParent() as GameController;
			TitleScreen = GetChild(0).GetChild<Sprite>(0);
			TitleScreen.Frame = 0;
		}
		private void _on_Timer_timeout()
		{
			if (TitleScreen.Frame == 0)
			{
				if (TextoAtual < Abertura.Count)
				{
					Texto.Text = Abertura[TextoAtual];
					TextoAtual += 1;
				}
			}
		}
		public override void _Process(float delta)
		{
			if (BugsBLL.Vida == 0)
			{
				Texto.Text = "";
				TitleScreen.Frame = 4;
			}
			switch (TitleScreen.Frame)
			{
				case 0:
					if (string.IsNullOrEmpty(Texto.Text))
						TitleScreen.Frame = 1;  
					break;
				case 1:
					if (KeyboardUtils.GetKey("ui_left", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_right", Keystatus.Pressed))
						TitleScreen.Frame = 2;
					if (KeyboardUtils.GetKey("ui_accept", Keystatus.Pressed))
					{
						Base.Portugues = false;
						TitleScreen.Frame = 3;
					}
					break;
				case 2:
					if (KeyboardUtils.GetKey("ui_left", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_right", Keystatus.Pressed))
						TitleScreen.Frame = 1;
					if (KeyboardUtils.GetKey("ui_accept", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
					{
						Base.Portugues = true;
						TitleScreen.Frame = 3;
					}
					break;
				case 3:
					if (KeyboardUtils.GetKey("ui_accept", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
					{
						Base.MudaNivel(1);
					}
					break;
				case 4:
					BugsBLL.Vida = 3;
					if (KeyboardUtils.GetKey("ui_accept", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
						TitleScreen.Frame = 3;
					break;
				default:
					Console.WriteLine("Default case");
					break;
			}
		}
	}
}
