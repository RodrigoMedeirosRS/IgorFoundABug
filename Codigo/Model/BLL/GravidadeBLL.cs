using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public class GravidadeBLL
    {
        private static Vector2 up2D = new Vector2(0,-1);
        private static Vector3 up3D = new Vector3(0,1,0);
        public static void Pular(ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.corpo2D.IsOnFloor())
                personagemDTO.gravidade = personagemDTO.forcaPulo;
        }
        public static void Gravidade(ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.gravidade > -9.8f)
                personagemDTO.gravidade -= personagemDTO.peso * personagemDTO.corpo.GetPhysicsProcessDeltaTime();
            
            else
                personagemDTO.gravidade = -9.8f;
            
            personagemDTO.corpo.MoveAndSlide(new Vector3(0, personagemDTO.gravidade * 50 * personagemDTO.corpo.GetPhysicsProcessDeltaTime(), 0), up3D);
        }
        public static void Gravidade2D(ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.gravidade < 9.8f)
                personagemDTO.gravidade += personagemDTO.peso * personagemDTO.corpo2D.GetPhysicsProcessDeltaTime();
            else
                personagemDTO.gravidade = 9.8f;

            personagemDTO.corpo2D.MoveAndSlide(new Vector2(0, personagemDTO.gravidade * 500 * personagemDTO.corpo2D.GetPhysicsProcessDeltaTime()), up2D);
        }
    }
}