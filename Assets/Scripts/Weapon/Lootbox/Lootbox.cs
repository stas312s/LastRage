using System;
using Extension;
using HealthSystem;
using ModestTree;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Weapon.Lootbox
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Lootbox: DamageTaker<CommonBullet>
    {
        [Inject] private IWeaponService _weaponService;
        [Inject] private IPlayerPosition _playerPosition;

        [SerializeField]private float _speed = 10f;

        private Vector2 _direction;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private bool _canRun = true;

        private int _bulletLayer;
        private int _lootBoxLayer;
        private float _distance = 13f;

        private void Start()
        {
            _bulletLayer = LayerMask.NameToLayer("Bullet");
            _lootBoxLayer = LayerMask.NameToLayer("LootBox");
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
             _direction = (_playerPosition.Position - (Vector2)transform.position).normalized;
        }

        private void Update()
        {
            if(_canRun)
            {
                Run();
            }
            
            if(Vector2.Distance(transform.position, _playerPosition.Position) > (_distance * 2))
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent<PlayerMove>(out var playerMove))
            {
                if (_weaponService.NotAvailableWeapons.Count > 0)
                {
                    var weapon = _weaponService.NotAvailableWeapons.Shuffle()[0];
                
                    _weaponService.TakeWeapon(weapon.Type);
                    
                }
                Destroy(gameObject);
                Physics2D.IgnoreLayerCollision(_lootBoxLayer, _bulletLayer, false);

            }
           
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if(Vector2.Distance(transform.position, _playerPosition.Position) < _distance)
            {
                base.OnTriggerEnter2D(other);
            }
        }

        private void Run()
        {
            
            Vector2 move = new Vector2(_direction.x * _speed * Time.deltaTime, 0); 
            _rb.velocity = (move);
        }

        protected override void Destroy()
        {
            _collider.isTrigger = false;
            _rb.gravityScale = 1;
            _canRun = false;
            _rb.velocity = Vector2.zero;
            Physics2D.IgnoreLayerCollision(_lootBoxLayer, _bulletLayer, true);
        }
    }
}