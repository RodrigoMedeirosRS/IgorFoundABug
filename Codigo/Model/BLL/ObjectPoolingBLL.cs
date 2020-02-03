using Godot;
using System.Collections.Generic;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class ObjectPoolingBLL
    {
        public static List<Node2D> criarPool(Node2D spawner, string cena, int quantidade)
        {
            List<Node2D> pool = new List<Node2D>();
            PackedScene objeto = (PackedScene)ResourceLoader.Load(cena);
            for (int i =0; i < quantidade; i ++)
            {
                pool.Add((Node2D)objeto.Instance());
                spawner.AddChild(pool[i]);
                pool[i].Visible = false;
                pool[i].GlobalPosition = new Vector2(0, 1000);
            }
            return pool;
        }
        public static object executarPooling(List<Node2D> pool)
        {
            object objeto = pool[0];
            pool.RemoveAt(0);
            pool.Add(objeto as Node2D);
            (objeto as Node2D).Visible = true;
            return objeto;
        }
    }
}