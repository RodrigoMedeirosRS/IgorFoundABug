using Godot;
namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class SingleMonophonicEmiterBLL
    {
        public static AudioStreamPlayer2D emissor;
        public static void Reproduzir(AudioStream som)
        {
            emissor.Stop();
            emissor.Stream = som;
            emissor.Play();
        }
    }
}