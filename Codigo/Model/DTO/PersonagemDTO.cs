using Godot;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class PersonagemDTO : ObjetoFisicoDTO
    {
        public Sprite SpritePersonagem { get; set; }
        public AnimationPlayer AnimationPlayer { get; set; }
        public bool Vivo { get; set; }
        public string UltimaAnimcacao { get; set; }
    }
}