using Godot;
using System;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Controller
{
	public class BulletController : Area2D
	{
		private AnimationPlayer Animacao;
		private Timer Tempo;
		private bool Inveritdo;
		public override void _Ready()
		{
			Animacao = GetChild<AnimationPlayer>(1);
			Tempo = GetChild<Timer>(2);
		}
		public override void _PhysicsProcess(float delta)
		{
			if (Animacao.CurrentAnimation == "Bullet")
				Position = Inveritdo ? Position - new Vector2(2,0) : Position + new Vector2(2,0);
				
		}
		public void Shoot(Vector2 inicio, bool invertido)
		{
			Inveritdo = invertido;
			GlobalPosition = inicio;
			Animacao.Play("Bullet", -1, 1);
			Tempo.Start();
		}
		private void _on_Bullet_body_entered(object body)
		{
			AnimarExplosao();
			if ((body as Node).IsInGroup("personagem"))
				(body as Bot).personagemDTO.Vivo = false;
			else if ((body as Node).IsInGroup("player"))
				(body as JogadorController).personagemDTO.Vivo = false;
		}
		private void _on_Timer_timeout()
		{
			AnimarExplosao();
		}
		private void _on_Bullet_area_entered(object area)
		{
			AnimarExplosao();
		}
		private void AnimarExplosao()
		{
			if (Animacao.CurrentAnimation == "Bullet")
				Animacao.Play("Explosao", -1, 1);
		}
	}
}
