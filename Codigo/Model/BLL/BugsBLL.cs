using IgorFoundABug.Codigo.Controller;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class BugsBLL
    {
        public static int Vida = 0;
        public static int Municao = 0;
        public static void Morre(JogadorController jogador)
        {
            Vida -= 1;
            Municao = jogador.personagemDTO.Municao > 0 ? -1 : 0;
        }
    }
}