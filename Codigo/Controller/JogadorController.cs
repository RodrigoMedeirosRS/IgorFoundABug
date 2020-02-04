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
		public override void _Ready()
		{
			personagemDTO.Vivo = true;
			personagemDTO.Vida = 1.0f;
			personagemDTO.Municao = 0;
			personagemDTO.Velocidade = 1f;
			personagemDTO.Peso = 80;
			personagemDTO.Gravidade = 9.8f;
			personagemDTO.ForcaPulo = -20;
			personagemDTO.Direcao = new Vector2(0,0);
			personagemDTO.Corpo2D = this;
			personagemDTO.UltimaAnimcacao = "";
			personagemDTO.AnimationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
			personagemDTO.SpritePersonagem = GetNode<Sprite>("./SpriteDoIgor");
			Arma =  GetNode<Node2D>("./Arma") as ArmaController;
		}
		public override void _PhysicsProcess(float delta)
		{
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
			if (KeyboardUtils.GetKey("ui_select", Keystatus.Pressed) && personagemDTO.Municao != 0)
			{
				personagemDTO.Municao -= 1;
				Arma.Atirar(personagemDTO, personagemDTO.SpritePersonagem.FlipH);
			}	
			if (KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
				GravidadeBLL.Pular(personagemDTO);
			
			personagemDTO.Direcao.x = (Convert.ToInt32(KeyboardUtils.GetKey("ui_right", Keystatus.Hold)) - Convert.ToInt32(KeyboardUtils.GetKey("ui_left", Keystatus.Hold)));
			
			MovimentoKinematicoBLL.Move2D(personagemDTO);
		}
		private void Animar()
		{
			if (personagemDTO.Vivo)
			{
				AnimationView.ExecutarAnimacao(personagemDTO.Corpo2D.IsOnFloor() && personagemDTO.Direcao.x == 0, "Idle", personagemDTO);
				AnimationView.ExecutarAnimacao(personagemDTO.Corpo2D.IsOnFloor() && personagemDTO.Direcao.x != 0, "Walk", personagemDTO);
				AnimationView.ExecutarAnimacao(!personagemDTO.Corpo2D.IsOnFloor(), "Jump", personagemDTO);
				Arma.Visible = personagemDTO.Municao != 0;
				Arma.Scale = new Vector2(1 - (2 * Convert.ToInt32(AnimationView.Flip2D(personagemDTO))), 1);				
			}
			AnimationView.ExecutarAnimacao(!personagemDTO.Vivo, "Morte", personagemDTO);
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "Morte")
				GetTree().ReloadCurrentScene();
		}
	}
}
