using Godot;
using System;


namespace IgorFoundABug.Codigo.Model.Utils
{
	public class Espinho : Area2D
	{
		[Signal]
		public delegate void MorreIgor();
		private void _on_Deathbox_body_entered(object body)
		{
			if (body is KinematicBody2D)
			{
				var objeto = (KinematicBody2D)body;
				if (objeto.IsInGroup("player"))
					EmitSignal(nameof(MorreIgor));
			}
		}

	}
}
