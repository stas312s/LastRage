using UnityEngine;
using Weapon;

namespace HealthSystem
{
    public abstract class DamageTaker<TBullet> : MonoBehaviour, IHealth where TBullet: Bullet
    {
        public float HealthPoint => _healthPoint;
        
        [SerializeField] private float _healthPoint = 1;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<TBullet>(out var bullet))
            {
                TakeDamage(bullet.Damage);
                if (bullet.NeedDestroy)
                {
                    Destroy(bullet.gameObject);
                }
            }
        }
        
        public virtual void TakeDamage( float damage)
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