using Godot;
using System;

namespace IgorFoundABug.Codigo.Controller
{
    public class DeathAreaController : Area2D
    {
        private void _on_Deathbox_body_entered(object body)
		{
			if ((body as Node).IsInGroup("player"))
				(body as JogadorController).IgorDTO.Vivo = false;	
		}
    }
}