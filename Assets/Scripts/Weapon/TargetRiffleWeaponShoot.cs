using UnityEngine;
using Zenject;

namespace Weapon
{
    public class TargetRiffleWeaponShoot: WeaponShoot<TargetRiffle>
    {
        public override WeaponType Type => WeaponType.Riffle;
        public override float Damage => _damage;
        public override float ShootDelay => _shootDelay;
        protected override float BulletSpeed => _bulletSpeed;

        [SerializeField]private float _damage;
        [SerializeField]private float _shootDelay;
        [SerializeField]private float _bulletSpeed;
        [SerializeField] private TargetRiffle _targetRifflePrefab;

        
        protected override void Shoot()
        {

            var targetRiffle = SpawnBullet(_targetRifflePrefab);
            
    
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - transform.position;
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            targetRiffle.transform.rotation = rotation;
            Rigidbody2D rb = targetRiffle.GetComponent<Rigidbody2D>();
            rb.velocity = direction * BulletSpeed;
        
        }
        
    }
}