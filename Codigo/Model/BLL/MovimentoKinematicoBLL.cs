using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class MovimentoKinematicoBLL
    {
        public static void Move2D(PersonagemDTO personagemDTO)
        {
            personagemDTO.Corpo2D.MoveAndCollide(personagemDTO.Direcao);
        }
    }
}