using System;

namespace IgorFoundABug.Codigo.Model.DTO
{
    public class JogadorDTO : PersonagemDTO
    {
        public float vida { get; set; }
        public int municao { get; set; }
    }
}