using Godot;
using System;
using IgorFoundABug.Codigo.Controller.Utils;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;
using IgorFoundABug.Codigo.View;


namespace IgorFoundABug.Codigo.Controller
{
	public class JogadorController : KinematicBody2D
	{
		public JogadorDTO personagemDTO = new JogadorDTO();
		private ArmaController Arma;
		private Timer Combo;
		public override void _Ready()
		{
			BugsBLL.jogador = this;
			GlobalPosition = BugsBLL.Spawnpoint;
			personagemDTO.Vivo = true;
			personagemDTO.Vida = 1.0f;
			personagemDTO.Municao = BugsBLL.Municao;
			personagemDTO.Velocidade = 1f;
			personagemDTO.Peso = 80;
			personagemDTO.Gravidade = 9.8f;
			personagemDTO.ForcaPulo = -20;
			personagemDTO.Direcao = new Vector2(0,0);
			personagemDTO.Corpo2D = this;
			personagemDTO.UltimaAnimcacao = "";
			personagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
			personagemDTO.SpritePersonagem = GetNode<Sprite>("./SpriteDoIgor");
			Combo = GetNode<Timer>("./Combo");
			Arma =  GetNode<Node2D>("./Arma") as ArmaController;
		}
		public override void _PhysicsProcess(float delta)
		{
			if (!BugsBLL.FlyBug)
				GravidadeBLL.Gravidade2D(personagemDTO);
			Acoes();
		}

		private void Acoes()
		{
			if (personagemDTO.Vivo)
				Movimento();
			Animar();
		}
		private void Movimento()
		{
			BugsBLL.FullCombo();
			if (KeyboardUtils.GetKey("ui_select", Keystatus.Pressed) && personagemDTO.Municao != 0)
			{
				personagemDTO.Municao -= 1;
				Arma.Atirar(personagemDTO, personagemDTO.SpritePersonagem.FlipH);
			}	
			if (KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
			{
				BugsBLL.FlyBug = false;
				GravidadeBLL.Pular(personagemDTO);
				BugsBLL.NoCombo();
			}
			
			personagemDTO.Direcao.x = (Convert.ToInt32(KeyboardUtils.GetKey("ui_right", Keystatus.Hold)) - Convert.ToInt32(KeyboardUtils.GetKey("ui_left", Keystatus.Hold)));
			if(KeyboardUtils.GetKey("ui_right", Keystatus.Pressed) || KeyboardUtils.GetKey("ui_left", Keystatus.Pressed))
			{
				BugsBLL.Combo += 1;
				Combo.Start(1);
			}
				
			MovimentoKinematicoBLL.Move2D(personagemDTO);
		}
		private void Animar()
		{
			if (personagemDTO.Vivo)
			{
				AnimationView.ExecutarAnimacao(personagemDTO.Corpo2D.IsOnFloor() && personagemDTO.Direcao.x == 0, "Idle", personagemDTO);
				AnimationView.ExecutarAnimacao(personagemDTO.Corpo2D.IsOnFloor() && personagemDTO.Direcao.x != 0, "Walk", personagemDTO);
				AnimationView.ExecutarAnimacao(!personagemDTO.Corpo2D.IsOnFloor() && !BugsBLL.FlyBug,"Jump", personagemDTO);
				AnimationView.ExecutarAnimacao(BugsBLL.FlyBug,"FlyBug", personagemDTO);
				Arma.Visible = personagemDTO.Municao != 0;
				Arma.Scale = new Vector2(1 - (2 * Convert.ToInt32(AnimationView.Flip2D(personagemDTO))), 1);
			}
			AnimationView.ExecutarAnimacao(!personagemDTO.Vivo, "Morte", personagemDTO);
		}
		private void _on_Combo_timeout()
		{
			BugsBLL.Combo = 0;
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "Morte")
			{
				BugsBLL.Morre();
				GetTree().ReloadCurrentScene();
			}
		}
	}
}
