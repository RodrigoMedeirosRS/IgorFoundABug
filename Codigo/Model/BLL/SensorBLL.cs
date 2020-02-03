using Godot;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class SensorBLL
    {
        public static float? Detectar(RayCast2D sensor, string tipo)
        {
            if (sensor.IsColliding())
                if ((sensor.GetCollider() as Node).IsInGroup(tipo))
                    return sensor.GlobalPosition.DistanceTo(sensor.GetCollisionPoint());
            return null;
        }
    }
}