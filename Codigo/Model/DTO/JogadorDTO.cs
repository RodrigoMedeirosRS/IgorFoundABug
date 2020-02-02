using System;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class JogadorDTO : PersonagemDTO
    {
        public float Vida { get; set; }
        public int Municao { get; set; }
    }
}