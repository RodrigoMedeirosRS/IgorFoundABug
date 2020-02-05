using Godot;
using IgorFoundABug.Codigo.Controller;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class BugsBLL
    {
        public static int Vida = 3;
        public static int Municao = 0;
        public static bool FlyBug = false;
        public static int Combo = 0;
        public static Vector2 Spawnpoint = new Vector2(34.28f ,25.9883f);
        public static JogadorController jogador;
        public static void Morre()
        {  
            FlyBug = false;
            Vida -= 1;
            Municao = jogador.personagemDTO.Municao > 0 ? -1 : 0;
            if (jogador.personagemDTO.SpritePersonagem.FlipV == true)
                FlyBug = true;
        }
        public static void FullCombo()
        {
            if (Combo >= 20 && !FlyBug)
            {
                jogador.personagemDTO.SpritePersonagem.FlipV = true;
                jogador.personagemDTO.Velocidade = 2f;
                jogador.personagemDTO.ForcaPulo = -40;
                jogador.personagemDTO.Municao = 0;
                Combo = 0;
            }
        }
        public static void NoCombo()
        {
            jogador.personagemDTO.SpritePersonagem.FlipV = false;
            jogador.personagemDTO.Velocidade = 1f;
            jogador.personagemDTO.ForcaPulo = -20;
        }
    }
}