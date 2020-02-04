using Godot;
using System.Collections.Generic;
using IgorFoundABug.Codigo.Model.BLL;
using IgorFoundABug.Codigo.Model.DTO;

namespace IgorFoundABug.Codigo.Controller
{
    public class ArmaController : Node2D
    {
        private List<Node> bulletPool;
        public override void _Ready()
        {
            bulletPool = ObjectPoolingBLL.criarPool(GetNode<Node>("/root/Base/NivelCarregado/Level/Spawners"),"res://Cenas/Objetos/Bullet.tscn",10);  
        }
        public void Atirar(PersonagemDTO personagem, bool invertido)
        {
            BulletController disparo = (ObjectPoolingBLL.executarPooling(bulletPool) as BulletController);
            Vector2 direcao = invertido ? new Vector2(GlobalPosition.x -10, GlobalPosition.y) : new Vector2(GlobalPosition.x +10, GlobalPosition.y);
            disparo.Shoot(direcao, invertido);
        }
    }

}
