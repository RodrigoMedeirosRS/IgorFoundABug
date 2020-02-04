using Godot;

namespace IgorFoundABug.Codigo.Controller
{
	public class PowerUPController : Area2D
	{
		private CollisionShape2D colisor;
		public override void _Ready()
		{
			colisor = GetNode<CollisionShape2D>("./CollisionShape2D");
			colisor.Disabled = false;
		}
		public void Drop(Vector2 posicao)
		{
			Visible = true;
			colisor.Disabled = false;
			GlobalPosition = posicao;
		}
		private void _on_PowerUP_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player"))
			{
				(body as JogadorController).personagemDTO.Municao += 3;
				Visible = false;
				colisor.Disabled = true;	
			}
		}
	}
}


