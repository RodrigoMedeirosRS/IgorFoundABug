using Godot;
using System;

namespace IgorFoundABug.Codigo.Model.Utils
{
	public class Espinho : Sprite
	{
		private void _on_StaticBody2D_body_entered(object body)
		{
			GD.Print(body);
		}
	}
}
