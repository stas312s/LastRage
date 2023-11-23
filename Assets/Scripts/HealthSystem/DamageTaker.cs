using System;
using ModestTree;
using UnityEngine;
using Weapon;

namespace HealthSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
    public abstract class DamageTaker<TBullet> : MonoBehaviour, IHealth where TBullet: Bullet
    {

        protected Rigidbody2D _rb;
        public float HealthPoint => _healthPoint;
        
        [SerializeField] private float _healthPoint = 1;
        
        protected Animator _animator;
        protected Collider2D _collider2D;

        
        protected virtual void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
        }

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