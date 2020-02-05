using Godot;
using IgorFoundABug.Codigo.Model.BLL;

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
				BugsBLL.Spawnpoint = new Vector2(34.28f ,25.9883f);
				System.Threading.Thread.Sleep(500);
				Base.MudaNivel(Base.NivelAtual += 1);
			}
		}
	}
}
