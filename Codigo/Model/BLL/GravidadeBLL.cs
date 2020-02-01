using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public class GravidadeBLL
    {
        public static void Pular(ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = personagemDTO.corpo == null ? 10 : -10;
        }
        public static void Gravidade(ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = personagemDTO.gravidade > -9.8f? personagemDTO.peso * personagemDTO.corpo.GetPhysicsProcessDeltaTime() : 9.8f;
            
            personagemDTO.corpo.MoveAndSlide(new Vector3(0, personagemDTO.gravidade * 50 * personagemDTO.corpo.GetPhysicsProcessDeltaTime(), 0));
        }
        public static void Gravidade2D(ObjetoFisicoDTO personagemDTO)
        {
            personagemDTO.gravidade = personagemDTO.gravidade > 9.8f? personagemDTO.peso * personagemDTO.corpo2D.GetPhysicsProcessDeltaTime() : 9.8f;

            personagemDTO.corpo2D.MoveAndSlide(new Vector2(0, personagemDTO.gravidade * 200 * personagemDTO.corpo2D.GetPhysicsProcessDeltaTime()));
        }
    }
}