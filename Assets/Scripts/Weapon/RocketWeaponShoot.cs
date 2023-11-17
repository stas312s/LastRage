using UnityEngine;

namespace Weapon
{
    public class RocketWeaponShoot: WeaponShoot<Rocket>
    {
        public override WeaponType Type => WeaponType.Rocket;
        public override float Damage => _damage;
        public override float ShootDelay => 0.4f;
        protected override float BulletSpeed => _bulletSpeed;

        [SerializeField] private int _damage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private Rocket _rocketPrefab;

        protected override void Shoot()
        {

            var rocket = SpawnBullet(_rocketPrefab);
            
    
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
            rb.velocity = direction * BulletSpeed;
        
        }
    }
}