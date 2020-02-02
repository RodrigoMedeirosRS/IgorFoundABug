using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;

namespace IgorFoundABug.Codigo.Controller
{
    public class ArmaController : Node2D
    {
        List<Node> bulletPool;
        public override void _Ready()
        {
            bulletPool = ObjectPoolingBLL.criarPool(GetParent().GetParent().GetParent().GetChild<Node2D>(1),"res://Cenas/Objetos/Bullet.tscn",10);  
        }
        public void Atirar(bool Inverido)
        {
            BulletController disparo = (ObjectPoolingBLL.executarPooling(bulletPool) as BulletController);
            disparo.Shoot(new Vector2(GlobalPosition.x +3, GlobalPosition.y));
        }
    }

}
