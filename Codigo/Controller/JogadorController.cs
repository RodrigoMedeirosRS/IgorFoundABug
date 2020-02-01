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
            IgorDTO.Velocidade = 1f;
            IgorDTO.Peso = 80;
            IgorDTO.Gravidade = 9.8f;
            IgorDTO.ForcaPulo = -20;
            IgorDTO.Direcao = new Vector2(0,0);
            IgorDTO.Corpo2D = this;
            IgorDTO.UltimaAnimcacao = "";
            IgorDTO.AnimationPlaryer = GetChild<AnimationPlayer>(0);
            IgorDTO.SpritePersonagem = GetChild<Sprite>(1);
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
            
            IgorDTO.Direcao.x = (Convert.ToInt32(KeyboardUtils.GetKey("ui_right", Keystatus.Hold)) - Convert.ToInt32(KeyboardUtils.GetKey("ui_left", Keystatus.Hold)));
            
            MovimentoKinematicoBLL.Move2D(IgorDTO);
        }
        private void Animar()
        {
            AnimationView.ExecutarAnimacao(IgorDTO.Corpo2D.IsOnFloor() && IgorDTO.Direcao.x == 0, "Idle", IgorDTO);
            AnimationView.ExecutarAnimacao(IgorDTO.Corpo2D.IsOnFloor() && IgorDTO.Direcao.x != 0, "Walk", IgorDTO);
            AnimationView.ExecutarAnimacao(!IgorDTO.Corpo2D.IsOnFloor(), "Jump", IgorDTO);
            AnimationView.Flip2D(IgorDTO);
        }
    }
}

