using Godot;
using System;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Controller;
public class DevController : Area2D
{
	private AnimationPlayer animationPlayer;
	private JogadorController jogador;
	private Sprite devSprite;
	private bool inverte;
	private bool vivo;
	private bool ativo;
	private AudioStream KillSound;
	public override void _Ready()
	{
		KillSound = ResourceLoader.Load("res://Recursos/Sons/powerup.wav") as AudioStream;
		ativo = false;
		inverte = true;
		vivo = true;
		jogador = GetParent().GetParent().GetChild(0).GetNode("./Igor") as JogadorController;
		animationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
		devSprite = GetNode<Sprite>("./Sprite");
		devSprite.FlipH = inverte;
	}
	public override void _PhysicsProcess(float delta)
	{
		ativo = !jogador.paused;
		if (ativo)
		{
			devSprite.FlipH = inverte;
			if (vivo)
			{
				if (animationPlayer.CurrentAnimation != "Run")
					animationPlayer.Play("Run", -1, 1);
				if (inverte)
					Position -= new Vector2(50 * delta, 0);
				else
					Position += new Vector2(50 * delta, 0);
			}
			else
			{   
				if (animationPlayer.CurrentAnimation != "Morte")
				animationPlayer.Play("Morte", -1, 1);
			}
		}
	}
	private void _on_Dev_body_entered(object body)
	{
		if (!(body as Node).IsInGroup("player"))
		{
			if (inverte)
				inverte = false;
			else
				inverte = true;
		}
	}
	private void _on_Dev_area_entered(object area)
	{
		if ((area as Node).IsInGroup("bullet"))
		{
			SingleMonophonicEmiterBLL.Reproduzir(KillSound);
			vivo = false;
		}
	}
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if(anim_name == "Morte")
			QueueFree();
	}
}
