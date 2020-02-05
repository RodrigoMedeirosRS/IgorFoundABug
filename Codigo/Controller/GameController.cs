using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;
using System.Threading;
namespace IgorFoundABug.Codigo.Controller
{
	public class GameController : AudioStreamPlayer2D
	{
		private List<PackedScene> Niveis = new List<PackedScene>();
    	private Node NivelCarregado;
		public int NivelAtual = 1;
    	public override void _Ready()
    	{
			SingleMonophonicEmiterBLL.emissor = this;
			OS.WindowMaximized = true;
			NivelCarregado = GetChild(0);
        	DefineListaDeNiveis();
        	MudaNivel(NivelAtual);
    	}
    	private void DefineListaDeNiveis()
    	{
        	Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-01.tscn"));
        	Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-02.tscn"));
    	}
    	public void MudaNivel(int ProximoNivel)
    	{
        	if (NivelCarregado.GetChildCount() > 0)
        		NivelCarregado.GetChild(0).QueueFree();
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
