using Godot;

using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.View;

namespace IgorFoundABug.Codigo.Controller
{
    public class BoxController : StaticBody2D
    {
        private AudioStream BoxSound;
        
        public PersonagemDTO personagemDTO = new PersonagemDTO();
        public override void _Ready()
        {
            BoxSound = ResourceLoader.Load("res://Recursos/Sons/powerup.wav") as AudioStream;
            personagemDTO.Vivo = true;
            personagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        }
        public override void _PhysicsProcess(float delta)
	    {
            if (!personagemDTO.Vivo && personagemDTO.AnimationPlayer.CurrentAnimation != "Destruido" && personagemDTO.AnimationPlayer.CurrentAnimation != "")
                SingleMonophonicEmiterBLL.Reproduzir(BoxSound);
            if (!personagemDTO.Vivo)
                AnimationView.ExecutarAnimacao(true, "Destruido", personagemDTO);
        }
    }
}

