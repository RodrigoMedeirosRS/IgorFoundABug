using Godot;
using System.Collections.Generic;

namespace IgorFoundABug.Codigo.Model.BLL
{
    public static class ObjectPoolingBLL
    {
        public static List<Node> criarPool(Node spawner, string cena, int quantidade)
        {
            List<Node> pool = new List<Node>();
            PackedScene objeto = ResourceLoader.Load(cena) as PackedScene;
            for (int i =0; i < quantidade; i ++)
            {
                pool.Add(objeto.Instance() as Node);
                spawner.AddChild(pool[i]);
            }
            return pool;
        }
        public static object executarPooling(List<Node> pool)
        {
            object objeto = pool[0];
            pool.RemoveAt(0);
            pool.Add(objeto as Node);
            return objeto;
        }
    }
}