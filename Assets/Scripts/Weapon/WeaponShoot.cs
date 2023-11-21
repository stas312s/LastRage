using UnityEngine;
using Zenject;
using Extension;

namespace Weapon
{
    public abstract class WeaponShoot<TBullet> : BaseWeapon where TBullet: Bullet
    {
        [Inject] private DiContainer _container;
        
        public override Sprite Icon => _icon;
        
        
        
        [SerializeField] protected Vector3 Offset = new Vector3(0.5f, 0 ,0);
        
        protected int FireButton = 0;
        protected virtual float BulletSpeed => 10f;

        [SerializeField] private Sprite _icon;
        
        private float _tempTime;
        
        private void Start()
        {
            _tempTime = Time.time;
        }


        protected virtual void Update()
        {
            if (Time.time - _tempTime >= ShootDelay)
            {
                if (Input.GetMouseButton(FireButton))
                {
                    Shoot();
                    _tempTime = Time.time;
                }
                

            }
        
        }

        protected abstract void Shoot();

        protected virtual TBullet SpawnBullet( TBullet bulletPrefab)
        {
            
            TBullet bullet = _container.Instantiate(bulletPrefab, transform.position + Offset);
            bullet.Damage = Damage;
            return bullet;
        }



    }
}