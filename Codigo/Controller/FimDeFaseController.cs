using Godot;

namespace IgorFoundABug.Codigo.Controller
{
	public class FimDeFaseController : Area2D
	{
		private GameController Base;
		public override void _Ready()
		{
			Base = GetNode("/root/Base") as GameController;
		}
		private void _on_FimDeFase_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player"))
			{
				System.Threading.Thread.Sleep(500);
				Base.MudaNivel(Base.NivelAtual += 1);
			}
		}
	}
}
