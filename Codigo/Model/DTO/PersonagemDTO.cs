using Godot;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class PersonagemDTO : ObjetoFisicoDTO
    {
        public AnimationPlayer AnimationPlaryer { get; set; }
        public string UltimaAnimcacao { get; set; }
    }
}