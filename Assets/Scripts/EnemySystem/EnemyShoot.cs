
using System;
using System.Collections;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace EnemySystem
{
    public class EnemyShoot: Enemy
    {
        [Inject] private IPlayerPosition _playerPosition;
        
        [SerializeField] private int _damage;
        [SerializeField] private int _bulletSpeed;
        [SerializeField] private EnemyCommonBullet _bulletPrefab;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShootDelay());
            
        }

        private void Shoot()
        {
            EnemyCommonBullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            bullet.Damage = _damage;
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            Vector2 direction = (_playerPosition.Position - (Vector2)transform.position).normalized;
            rb.velocity = direction * _bulletSpeed;

        }

        private IEnumerator ShootDelay()
        {
            while (_playerPosition.Transform != null)
            {
                if (Vector2.Distance(_playerPosition.Position, (Vector2) transform.position) <= 12f)
                {
                    Shoot();
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}