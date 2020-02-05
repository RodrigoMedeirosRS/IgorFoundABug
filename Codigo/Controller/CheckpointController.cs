using Godot;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.View;


namespace IgorFoundABug.Codigo.Controller
{
	public class CheckpointController : Area2D
	{
		private bool Desativado;
		private PersonagemDTO PersonagemDTO = new PersonagemDTO();
		public override void _Ready()
		{
			Desativado = true;
			PersonagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
		}
		private void _on_Checkpoint_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player") && Desativado)
			{
				AnimationView.ExecutarAnimacao(true, "Active", PersonagemDTO);
				BugsBLL.Spawnpoint = GlobalPosition;
			}
		}
	}
}
