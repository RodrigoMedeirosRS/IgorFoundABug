using Godot;

namespace IgorFoundABug.Codigo.Controller
{
	public class PowerUPController : Area2D
	{
		public void Dropar(Vector2 local)
		{

			GlobalPosition = local;
			GD.Print("Aqui");
			GD.Print(GlobalPosition);
		}
		private void _on_PowerUP_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player"))
			{
				(body as JogadorController).personagemDTO.Municao += 3;
				QueueFree();	
			}
		}
	}
}


