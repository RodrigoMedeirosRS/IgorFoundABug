using Godot;
using System;

using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
    public class GameController : Node2D
    {       
        public override void _Ready()
        {
        
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
