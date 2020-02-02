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
		public JogadorDTO IgorDTO = new JogadorDTO();
		private ArmaController Arma;
		public override void _Ready()
		{
			IgorDTO.Vivo = true;
			IgorDTO.Vida = 1.0f;
			IgorDTO.Municao = 0;
			IgorDTO.Velocidade = 1f;
			IgorDTO.Peso = 80;
			IgorDTO.Gravidade = 9.8f;
			IgorDTO.ForcaPulo = -20;
			IgorDTO.Direcao = new Vector2(0,0);
			IgorDTO.Corpo2D = this;
			IgorDTO.UltimaAnimcacao = "";
			IgorDTO.AnimationPlaryer = GetChild<AnimationPlayer>(0);
			IgorDTO.SpritePersonagem = GetChild<Sprite>(1);
			Arma = GetChild<Node2D>(3) as ArmaController;
		}
		public override void _PhysicsProcess(float delta)
		{
			GravidadeBLL.Gravidade2D(IgorDTO);
			Acoes();
		}

		private void Acoes()
		{
			if (IgorDTO.Vivo)
				Movimento();
			Animar();
		}
		private void Movimento()
		{
			if (KeyboardUtils.GetKey("ui_select", Keystatus.Pressed))
				Arma.Atirar(IgorDTO.SpritePersonagem.FlipH);
			if (KeyboardUtils.GetKey("ui_up", Keystatus.Pressed))
				GravidadeBLL.Pular(IgorDTO);
			
			IgorDTO.Direcao.x = (Convert.ToInt32(KeyboardUtils.GetKey("ui_right", Keystatus.Hold)) - Convert.ToInt32(KeyboardUtils.GetKey("ui_left", Keystatus.Hold)));
			
			MovimentoKinematicoBLL.Move2D(IgorDTO);
		}
		private void Animar()
		{
			if (IgorDTO.Vivo)
			{
				AnimationView.ExecutarAnimacao(IgorDTO.Corpo2D.IsOnFloor() && IgorDTO.Direcao.x == 0, "Idle", IgorDTO);
				AnimationView.ExecutarAnimacao(IgorDTO.Corpo2D.IsOnFloor() && IgorDTO.Direcao.x != 0, "Walk", IgorDTO);
				AnimationView.ExecutarAnimacao(!IgorDTO.Corpo2D.IsOnFloor(), "Jump", IgorDTO);
				Arma.Visible = IgorDTO.Municao != 0;
				Arma.Scale = new Vector2(1 - (2 * Convert.ToInt32(AnimationView.Flip2D(IgorDTO))), 1);				
			}
			AnimationView.ExecutarAnimacao(!IgorDTO.Vivo, "Morte", IgorDTO);
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "Morte")
				GetTree().ReloadCurrentScene();
		}
	}
}
