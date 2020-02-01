using Godot;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class ObjetoFisicoDTO
    {
        public KinematicBody Corpo { get; set; }
        public KinematicBody2D Corpo2D { get; set; }
        public float Gravidade { get; set; }
        public float Peso { get; set; }
        public float Velocidade { get; set; }
        public float ForcaPulo { get; set; }
        public Vector2 Direcao;
    }
}