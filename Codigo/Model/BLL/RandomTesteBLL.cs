using Godot;
namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class RandomTesteBLL
    {
        public static bool testar(double chance)
        {
            GD.Randomize();
            var resultado = GD.RandRange(0, 1);
            return resultado <= chance;
        }
    }
}