using System;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public class Circle: CommonBullet
    {
        [Inject] private IPlayerPosition _playerPosition;
        public Vector3 Offset { get; set; }
        private void Update()
        {
            transform.position = new Vector3(_playerPosition.Position.x +Offset.x, _playerPosition.Position.y + Offset.y, 0);
            
        }

       

        protected override void Destroy()
        {
            
        }
    }
}