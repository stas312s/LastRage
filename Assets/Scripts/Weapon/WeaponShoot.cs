using UnityEngine;

namespace Weapon
{
    public abstract class WeaponShoot: MonoBehaviour
    {
        protected virtual int Damage => 1;
        protected  virtual float BulletSpeed => 10f;
        protected virtual float ShootDelay => 0.1f;
        protected  Vector3 Offset = new Vector3(0.5f, 0 ,0);
        protected  int FireButton = 0;
        protected  float _tempTime;
        
        private void Start()
        {
            _tempTime = Time.time;
        }


        private void Update()
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



    }
}