using Godot;

namespace IgorFoundABug.Codigo.Controller.Utils
{
    public enum Keystatus {Pressed, Released, Hold};
    public static class KeyboardUtils
    {
        public static bool GetKey(string key, Keystatus keystatus)
        {
            switch (keystatus)
            {
                case Keystatus.Pressed:
                    return Input.IsActionJustPressed(key);
                case Keystatus.Hold:
                    return Input.IsActionPressed(key);
                case Keystatus.Released:
                    return Input.IsActionJustReleased(key);
                default:
                    return false;
            }
        }

    }
}