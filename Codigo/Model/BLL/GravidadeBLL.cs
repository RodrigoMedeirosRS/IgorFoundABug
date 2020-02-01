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
            if (personagemDTO.Corpo2D.IsOnFloor())
                personagemDTO.Gravidade = personagemDTO.ForcaPulo;
        }
        public static void Gravidade(ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.Gravidade > -9.8f)
                personagemDTO.Gravidade -= personagemDTO.Peso * personagemDTO.Corpo.GetPhysicsProcessDeltaTime();
            
            else
                personagemDTO.Gravidade = -9.8f;
            
            personagemDTO.Corpo.MoveAndSlide(new Vector3(0, personagemDTO.Gravidade * 50 * personagemDTO.Corpo.GetPhysicsProcessDeltaTime(), 0), up3D);
        }
        public static void Gravidade2D(ObjetoFisicoDTO personagemDTO)
        {
            if (personagemDTO.Gravidade < 9.8f)
                personagemDTO.Gravidade += personagemDTO.Peso * personagemDTO.Corpo2D.GetPhysicsProcessDeltaTime();
            else
                personagemDTO.Gravidade = 9.8f;

            personagemDTO.Corpo2D.MoveAndSlide(new Vector2(0, personagemDTO.Gravidade * 500 * personagemDTO.Corpo2D.GetPhysicsProcessDeltaTime()), up2D);
        }
    }
}