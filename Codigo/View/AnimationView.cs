using Godot;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.View
{
    public static class AnimationView
    {
        public static void ExecutarAnimacao(bool condition, string nomeAnimacao, PersonagemDTO personagemDTO)
        {
            if (condition && personagemDTO.UltimaAnimcacao != nomeAnimacao)
            {
                personagemDTO.UltimaAnimcacao = nomeAnimacao;
                personagemDTO.AnimationPlaryer.Play(nomeAnimacao, -1, 1);
            }
        }
        public static void Flip2D(PersonagemDTO personagemDTO)
        {
            if (personagemDTO.Direcao.x != 0)
                personagemDTO.SpritePersonagem.FlipH = personagemDTO.Direcao.x < 0;
        }
    }
}