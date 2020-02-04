using Godot;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.Controller;

namespace IgorFoundABug.Codigo.Model.Utils
{
    public class Camera2DFollow : Camera2D
    {
        public KinematicBody2D player;
        public JogadorDTO jogadorDTO;
        public Label marcadorDeVida;
        public Label marcadorDeMunicao;
        public Sprite hudMunicao;
        public override void _Ready()
        {
            marcadorDeVida = GetNode<Label>("./Vida/Texto");
            marcadorDeMunicao = GetNode<Label>("./Municao/Texto");
            hudMunicao = GetNode<Sprite>("./Municao");
            player = GetNode<KinematicBody2D>("/root/Base/Jogador/Igor");
            jogadorDTO = (player as JogadorController).personagemDTO;
        }
        public override void _PhysicsProcess(float delta)
        {
            hudMunicao.Visible = jogadorDTO.Municao != 0;
            marcadorDeMunicao.Text = jogadorDTO.Municao.ToString();
        }
        public override void _Process(float delta)
        {
            Position = new Vector2(player.Position.x, 34f);
        }
    }
}

