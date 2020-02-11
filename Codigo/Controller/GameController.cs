using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
	public class GameController : AudioStreamPlayer
	{
		private List<PackedScene> Niveis = new List<PackedScene>();
		private List<AudioStream> Musicas = new List<AudioStream>();
		private Node NivelCarregado;
		public int NivelAtual = 0;
		public bool Portugues = false;
		public override void _Ready()
		{
			OS.WindowMaximized = true;
			DefineListaDeNiveis();
			SingleMonophonicEmiterBLL.emissor = this;
			SingleMonophonicEmiterBLL.musica = GetChild<AudioStreamPlayer>(0);
			SingleMonophonicEmiterBLL.Tocar(Musicas[0]);
			NivelCarregado = GetChild(1);
			MudaNivel(NivelAtual);
		}
		private void DefineListaDeNiveis()
		{
			Musicas.Add((AudioStream)ResourceLoader.Load("res://Recursos/Musicas/Juhani_Junkala_Stage_0.ogg"));
			Musicas.Add((AudioStream)ResourceLoader.Load("res://Recursos/Musicas/Juhani_Junkala_Stage_1.ogg"));
			Musicas.Add((AudioStream)ResourceLoader.Load("res://Recursos/Musicas/Juhani_Junkala_Stage_2.ogg"));
			Musicas.Add((AudioStream)ResourceLoader.Load("res://Recursos/Musicas/Juhani_Junkala_Stage_1.ogg"));

			Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-00.tscn"));
			Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-01.tscn"));
			Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-02.tscn"));
			Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-03.tscn"));
		}
		public void MudaNivel(int ProximoNivel)
		{
			if (NivelCarregado.GetChildCount() > 0)
				NivelCarregado.GetChild(0).QueueFree();
			if (ProximoNivel != NivelAtual)
			{
				SingleMonophonicEmiterBLL.Tocar(Musicas[ProximoNivel]);
				BugsBLL.Spawnpoint = new Vector2(34.28f ,25.9883f);
				BugsBLL.FlyBug = false;
				BugsBLL.Combo = 0;
			}
			Node newLevel = (Node)Niveis[ProximoNivel].Instance();
			NivelCarregado.AddChild(newLevel);
			NivelAtual = ProximoNivel;
		}
		public override void _Process(float delta)
		{
			if (KeyboardUtils.GetKey("ui_cancel", Keystatus.Pressed))
				Input.SetMouseMode(Input.MouseMode.Visible);
		}
	}
}
