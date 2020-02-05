using Godot;

namespace IgorFoundABug.Codigo.Controller
{
	public class PowerUPController : Area2D
	{
		public override void _Ready()
		{
			SetCollisionLayerBit(0, false);
		}
		public void Drop(Vector2 posicao)
		{
			Visible = true;
			SetCollisionLayerBit(0, true);
			GlobalPosition = posicao;
		}
		private void _on_PowerUP_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player"))
			{
				SetCollisionLayerBit(0, false);
				Visible = false;
				(body as JogadorController).personagemDTO.Municao += 3;
			}
		}
	}
}
