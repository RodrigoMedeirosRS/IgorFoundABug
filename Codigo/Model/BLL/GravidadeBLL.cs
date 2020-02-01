using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public class GravidadeBLL
    {
        public static void Pular(ObjetoFisicoDTO personagemDTO, bool is2D)
        {
            personagemDTO.gravidade = is2D? -10 : 10;
        }
        public static void Gravidade(KinematicBody corpo, ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = personagemDTO.gravidade > -9.8f? -personagemDTO.peso * corpo.GetPhysicsProcessDeltaTime() : 9.8f;
            
            corpo.MoveAndSlide(new Vector3(0, personagemDTO.gravidade * 50 * corpo.GetPhysicsProcessDeltaTime(), 0));
        }
        public static void Gravidade2D(KinematicBody2D corpo, ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = personagemDTO.gravidade > 9.8f? personagemDTO.peso * corpo.GetPhysicsProcessDeltaTime() : 9.8f;

            corpo.MoveAndSlide(new Vector2(0, personagemDTO.gravidade * 200 * corpo.GetPhysicsProcessDeltaTime()));
        }
    }
}