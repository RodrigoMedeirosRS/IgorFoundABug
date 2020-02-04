using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
	public class GameController : AudioStreamPlayer2D
	{
		List<PackedScene> Niveis = new List<PackedScene>();
    	Node NivelCarregado;
    	public override void _Ready()
    	{
			SingleMonophonicEmiterBLL.emissor = this;
			OS.WindowMaximized = true;
			NivelCarregado = GetChild(0);
        	Define_Lista_de_Niveis();
        	Muda_Nivel(1);
    	}
    	private void Define_Lista_de_Niveis()
    	{
        	Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-01.tscn"));
        	Niveis.Add((PackedScene)ResourceLoader.Load("res://Level-02.tscn"));
    	}
    	public void Muda_Nivel(int nivel_atual)
    	{
        	if (NivelCarregado.GetChildCount() > 0)
        		NivelCarregado.GetChild(0).QueueFree();
        	Node newLevel = (Node)Niveis[nivel_atual].Instance();
        	NivelCarregado.AddChild(newLevel);
    	}
    	public override void _Process(float delta)
    	{
        	if (KeyboardUtils.GetKey("ui_cancel", Keystatus.Pressed))
            	Input.SetMouseMode(Input.MouseMode.Visible);
    	}
	}
}
