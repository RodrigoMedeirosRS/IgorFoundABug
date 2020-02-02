using Godot;
using System;

namespace IgorFoundABug.Codigo.Controller
{
	public class PowerUPController : Area2D
	{
		private void _on_PowerUP_body_entered(object body)
		{
			if (!(body as Node).IsInGroup("player"))
				return;
			(body as JogadorController).IgorDTO.Municao += 3;
			QueueFree();	
		}
	}
}


