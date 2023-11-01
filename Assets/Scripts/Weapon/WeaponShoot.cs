using UnityEngine;

namespace Weapon
{
    public abstract class WeaponShoot: MonoBehaviour
    {
        protected virtual int _damage => 1;
        protected  virtual float _bulletSpeed => 10f;
        protected virtual float _shootDelay => 0.1f;
        protected  Vector3 _offset = new Vector3(0.5f, 0 ,0);
        protected  int _fireButton = 0;
        protected  float _tempTime;
        
        private void Start()
        {
            _tempTime = Time.time;
        }


        private void Update()
        {
            if (Time.time - _tempTime >= _shootDelay)
            {
                if (Input.GetMouseButton(_fireButton))
                {
                    Shoot();
                    _tempTime = Time.time;
                }

            }
        
        }

        protected abstract void Shoot();



    }
}