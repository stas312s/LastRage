namespace Weapon
{
    public class RocketWeaponShoot: WeaponShoot
    {
        protected override int _damage => 5;
        protected override float _bulletSpeed => 20;
        protected override float _shootDelay => 0.4f;


        protected override void Shoot()
        {
            
        }
    }
}