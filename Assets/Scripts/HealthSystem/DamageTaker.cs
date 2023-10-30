using UnityEngine;
using Weapon;

namespace HealthSystem
{
    public abstract class DamageTaker<TBullet> : MonoBehaviour, IHealth where TBullet: Bullet
    {
        public int HealthPoint => _healthPoint;
        
        [SerializeField] private int _healthPoint = 1;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<TBullet>(out var bullet))
            {
                TakeDamage(bullet.Damage);
                Destroy(bullet.gameObject);
            }
        }
        
        public virtual void TakeDamage( int damage)
        {
            _healthPoint -= damage;
            if (_healthPoint <= 0)
            {
                Destroy();
            }
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}