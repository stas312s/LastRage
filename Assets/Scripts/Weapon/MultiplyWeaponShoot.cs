using UnityEngine;

namespace Weapon
{
    public class MultiplyWeaponShoot: WeaponShoot<Multiply>
    {
        protected override float Damage => _damage;
        protected override float ShootDelay => _shootDelay;
        protected override float BulletSpeed => _bulletSpeed;

        [SerializeField]private float _damage;
        [SerializeField]private float _shootDelay;
        [SerializeField]private float _bulletSpeed;
        [SerializeField] private Multiply _multiplyPrefab;

        private float _angleIncrement = 15;
        private float _projectileSpread = 45f;
        private float _numberOfProjectile = 5;
        
        protected override void Shoot()
        {
             Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //
            // 
            // var multiply = SpawnBullet(_multiplyPrefab); 
            // Rigidbody2D centralRB = multiply.GetComponent<Rigidbody2D>();
            // Vector3 centralDirection = (mousePosition - transform.position).normalized;
            // centralRB.velocity = centralDirection * _bulletSpeed; // bulletSpeed - скорость пули
            //
            // for (int i = -2; i < 3; i++)
            // {
            //     float radians = Mathf.Deg2Rad * (_angleIncrement * (i + 1));
            //     Vector3 direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
            //
            //     var multiplyOther = SpawnBullet(_multiplyPrefab); 
            //     Rigidbody2D rb = multiplyOther.GetComponent<Rigidbody2D>();
            //     rb.velocity = ((centralDirection + direction) * _bulletSpeed); // bulletSpeed - скорость пули
            // }

            var playerFacingDirection = (mousePosition - transform.position).normalized;

            float facingRotation = Mathf.Atan2(playerFacingDirection.y, playerFacingDirection.x) * Mathf.Rad2Deg;
            float startRotation = facingRotation - _projectileSpread / 2f;
            float angleIncrease = _projectileSpread / ((float) _numberOfProjectile - 1f);

            for (int i = 0; i < _numberOfProjectile; i++)
            {
                float tempRot = startRotation + angleIncrease * i;
                var newProjectile = SpawnBullet(_multiplyPrefab);
                var rb = newProjectile.GetComponent<Rigidbody2D>();
                if (rb)
                {
                    rb.velocity = (new Vector2(Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad)) * _bulletSpeed);
                   
                }
            }
        }
    }
}