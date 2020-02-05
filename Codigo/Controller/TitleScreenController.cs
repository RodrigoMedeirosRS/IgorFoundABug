using Godot;
using System;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller.Utils;

namespace IgorFoundABug.Codigo.Controller
{
    public class TitleScreenController : Node2D
    {
        private Sprite TitleScreen;
        private GameController Base;
        public override void _Ready()
        {
            Base = GetParent().GetParent() as GameController;
            TitleScreen = GetChild(0).GetChild<Sprite>(0);
            TitleScreen.Frame = 1;
        }
        public override void _Process(float delta)
        {   
            if (BugsBLL.Vida == 0)
                TitleScreen.Frame = 4;
            switch (TitleScreen.Frame)
            {
                case 0:
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

