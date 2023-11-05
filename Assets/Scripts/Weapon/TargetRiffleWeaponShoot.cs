using UnityEngine;
using Zenject;

namespace Weapon
{
    public class TargetRiffleWeaponShoot: WeaponShoot<TargetRiffle>
    {
        protected override float Damage => _damage;
        protected override float ShootDelay => _shootDelay;
        protected override float BulletSpeed => _bulletSpeed;

        [SerializeField]private float _damage;
        [SerializeField]private float _shootDelay;
        [SerializeField]private float _bulletSpeed;
        [SerializeField] private TargetRiffle _targetRifflePrefab;

        
        protected override void Shoot()
        {

            var targetRiffle = SpawnBullet(_targetRifflePrefab);
            
    
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - targetRiffle.transform.position;
            direction.Normalize(); 
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            targetRiffle.transform.rotation = rotation;
            Rigidbody2D rb = targetRiffle.GetComponent<Rigidbody2D>();
            rb.velocity = direction * BulletSpeed;
        
        }
        
    }
}