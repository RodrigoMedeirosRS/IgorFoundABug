using Godot;
namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class SingleMonophonicEmiterBLL
    {
        public static AudioStreamPlayer emissor;
        public static AudioStreamPlayer musica;
        public static void Reproduzir(AudioStream som) 
        {
            emissor.Stop();
            emissor.Stream = som;
            emissor.Play();
        }
        public static void Tocar(AudioStream som)
        {
            musica.Stop();
            musica.Stream = som;
            musica.Play();
        }
    }
}