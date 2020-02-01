using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public class GravidadeBLL
    {
        public static void Pular(ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = 10;
        }
        public static void Gravidade(KinematicBody corpo, ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.gravidade > -9.8f)
            {
                personagemDTO.gravidade -= personagemDTO.peso * corpo.GetPhysicsProcessDeltaTime();
            }
            else
            {
                personagemDTO.gravidade = -9.8f;
            }
            corpo.MoveAndSlide(new Vector3(0, personagemDTO.gravidade * 50 * corpo.GetPhysicsProcessDeltaTime(), 0));
        }
        public static void Gravidade2D(KinematicBody2D corpo, ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.gravidade > -9.8f)
            {
                personagemDTO.gravidade -= personagemDTO.peso * corpo.GetPhysicsProcessDeltaTime();
            }
            else
            {
                personagemDTO.gravidade = -9.8f;
            }
            corpo.MoveAndSlide(new Vector2(0, personagemDTO.gravidade * 50 * corpo.GetPhysicsProcessDeltaTime()));
        }
    }
}