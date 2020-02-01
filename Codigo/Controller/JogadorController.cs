using Godot;
using System;
using IgorFoundABug.Codigo.Controller.Utils;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;


namespace IgorFoundABug.Codigo.Controller
{
    public class JogadorController : KinematicBody2D
    {
        JogadorDTO igorDTO = new JogadorDTO();
        public override void _Ready()
        {
            igorDTO.vida = 1.0f;
            igorDTO.municao = 3;
            igorDTO.velocidade = 1f;
            igorDTO.peso = 80;
            igorDTO.gravidade = 9.8f;
            igorDTO.forcaPulo = -20;
            igorDTO.corpo2D = this;
        }
        public override void _PhysicsProcess(float delta)
        {
            GravidadeBLL.Gravidade2D(igorDTO);
            acoes();
        }

        private void acoes()
        {
            movimento();
        }

        private void movimento()
        {
            if (KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
            {
                GravidadeBLL.Pular(igorDTO);
            }
        }
    }
}

