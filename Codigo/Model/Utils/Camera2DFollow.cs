using Godot;

namespace IgorFoundABug.Codigo.Model.Utils
{
    public class Camera2DFollow : Camera2D
    {
        public KinematicBody2D player;
        public override void _Ready()
        {
            player = GetNode<KinematicBody2D>("/root/Base/Jogador/Igor");
        }
        public override void _Process(float delta)
        {
            Position = new Vector2(player.Position.x, 33.902f);
        }
    }
}

