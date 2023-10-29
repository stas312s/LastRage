
using System;
using System.Collections;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyShoot: Enemy
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _bulletSpeed;
        [SerializeField] private Transform _playerTransform;
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
            
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            rb.velocity = direction * _bulletSpeed;

        }

        private IEnumerator ShootDelay()
        {
            while (_playerTransform != null)
            {
                Shoot();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}