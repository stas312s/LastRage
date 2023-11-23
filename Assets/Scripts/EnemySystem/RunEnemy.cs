using UnityEngine.UI;
using Player.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
namespace EnemySystem
{
    public class RunEnemy: Enemy
    {
        [Inject] private IPlayerPosition _playerPosition;


        
        protected override void MonstrMove()
        {
            if (_playerPosition.Transform != null && HealthPoint > 0)
            {
                Vector2 direction = _playerPosition.Position - (Vector2)transform.position;
                direction.Normalize();
                direction.y = 0;
                Vector2 Move = new Vector2(direction.x * _speed * Time.deltaTime, direction.y); 
                _rb.velocity = (Move);
            }
        }
    }
}