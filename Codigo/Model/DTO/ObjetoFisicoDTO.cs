using Godot;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class ObjetoFisicoDTO
    {
        public KinematicBody corpo { get; set; }
        public KinematicBody2D corpo2D { get; set; }
        public float gravidade { get; set; }
        public float peso { get; set; }
        public float velocidade { get; set; }
    }
}