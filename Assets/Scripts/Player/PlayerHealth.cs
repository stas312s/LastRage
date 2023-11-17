using System;
using EnemySystem;
using HealthSystem;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: DamageTaker<EnemyCommonBullet>
    {
        
        protected override void Destroy()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent<Enemy>(out var enemy))
            {
                TakeDamage(enemy.Damage);
            }
        }
    }
}