using Godot;

using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.View;

namespace IgorFoundABug.Codigo.Controller
{
    public class BoxController : StaticBody2D
    {
        public PersonagemDTO personagemDTO = new PersonagemDTO();
        public override void _Ready()
        {
            personagemDTO.Vivo = true;
            personagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        }
        public override void _PhysicsProcess(float delta)
	    {
            if (!personagemDTO.Vivo)
                AnimationView.ExecutarAnimacao(true, "Destruido", personagemDTO);
        }
    }
}

