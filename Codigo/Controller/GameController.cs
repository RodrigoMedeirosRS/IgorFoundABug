using Godot;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
	public class GameController : AudioStreamPlayer2D
	{       
		public override void _Ready()
		{
			SingleMonophonicEmiterBLL.emissor = this;
			OS.WindowMaximized = true;
		}
		public override void _Process(float delta)
		{
			if (KeyboardUtils.GetKey("ui_cancel", Keystatus.Pressed))
			{
				GetTree().Quit();
			}
		}

	}
}
