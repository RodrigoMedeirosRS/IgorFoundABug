using Godot;
using System;
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
            igorDTO.peso = 60;
            igorDTO.gravidade = 9.8f;

        }
        public override void _PhysicsProcess(float delta)
        {
            GravidadeBLL.Gravidade2D(this, igorDTO);
        }
    }
}

