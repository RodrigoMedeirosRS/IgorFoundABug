using Godot;
using System;
using IgorFoundABug.Codigo.Controller.Utils;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.View;


namespace IgorFoundABug.Codigo.Controller
{
    public class JogadorController : KinematicBody2D
    {
        JogadorDTO IgorDTO = new JogadorDTO();
        public override void _Ready()
        {
            IgorDTO.vida = 1.0f;
            IgorDTO.municao = 3;
            IgorDTO.velocidade = 1f;
            IgorDTO.peso = 80;
            IgorDTO.gravidade = 9.8f;
            IgorDTO.forcaPulo = -20;
            IgorDTO.corpo2D = this;
            IgorDTO.UltimaAnimcacao = "";
            IgorDTO.AnimationPlaryer = GetChild<AnimationPlayer>(0);
        }
        public override void _PhysicsProcess(float delta)
        {
            GravidadeBLL.Gravidade2D(IgorDTO);
            Acoes();
        }

        private void Acoes()
        {
            Movimento();
            Animar();
        }
        private void Movimento()
        {
            if (KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
                GravidadeBLL.Pular(IgorDTO);
        }
        private void Animar()
        {
            AnimationView.ExecutarAnimacao(IgorDTO.corpo2D.IsOnFloor(), "Idle", IgorDTO);
            AnimationView.ExecutarAnimacao(!IgorDTO.corpo2D.IsOnFloor(), "Jump", IgorDTO);
        }
    }
}

