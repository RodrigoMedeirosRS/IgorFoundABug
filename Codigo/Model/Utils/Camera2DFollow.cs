using Godot;
using System;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.Controller;

namespace IgorFoundABug.Codigo.Model.Utils
{
    public class Camera2DFollow : Node2D
    {
        public KinematicBody2D player;
        public JogadorDTO jogadorDTO;
        public Label marcadorDeVida;
        public Label marcadorDeMunicao;
        public Sprite hudMunicao;
        public override void _Ready()
        {
            this.Position = new Vector2(34.28f, 33f);
            marcadorDeVida = GetNode<Label>("./Vida/Texto");
            marcadorDeMunicao = GetNode<Label>("./Municao/Texto");
            hudMunicao = GetNode<Sprite>("./Municao");
            player = GetParent().GetNode<KinematicBody2D>("./Igor");
            jogadorDTO = (player as JogadorController).personagemDTO;
        }
        public override void _PhysicsProcess(float delta)
        {
            hudMunicao.Visible = jogadorDTO.Municao != 0;
            marcadorDeMunicao.Text = jogadorDTO.Municao.ToString();
            marcadorDeVida.Text = BugsBLL.Vida.ToString();
        }
        public override void _Process(float delta)
        {
            try
            {
                this.Position = new Vector2(player.Position.x, 24f);
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}

