using Godot;
using System;

namespace IgorFoundABug.Codigo.Controller
{
	public class BulletController : Area2D
	{
		private AnimationPlayer animacao;
		public override void _Ready()
		{
			animacao = GetChild<AnimationPlayer>(1);
		}
		public override void _PhysicsProcess(float delta)
		{
			if (animacao.CurrentAnimation == "Bullet")
				Position += new Vector2(2,0);
		}
		public void Shoot(Vector2 inicio)
		{
			GlobalPosition = inicio;
			animacao.Play("Bullet", -1, 1);
		}
		private void _on_Bullet_body_entered(object body)
		{
			if (animacao.CurrentAnimation == "Bullet")
				animacao.Play("Explosao", -1, 1);
		}
	}
}
