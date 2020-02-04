using Godot;

using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
    public class GameController : Node2D
    {       
        public override void _Ready()
        {
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
