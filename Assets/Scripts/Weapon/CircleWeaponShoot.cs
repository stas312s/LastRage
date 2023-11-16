﻿using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public class CircleWeaponShoot: WeaponShoot<Circle>
    {
        public override float Damage => _damage;

        [SerializeField] private float _damage;
        [SerializeField] private Circle _circlePrefab;
        [SerializeField] private float _prefabScale;
        
        [SerializeField] private float _timeToScalePrefab;
        [SerializeField] private float _timeToScaleBullet;
        private Circle _circle;
        private float _endTime;
        private float _scaleTime;
        private float _bulletScale;

        protected override void Update()
        {
            if (Input.GetMouseButtonDown(FireButton))
            {
                Shoot();
             
                _endTime = _timeToScalePrefab;
                _bulletScale = 1.01f;

            }
            
            if (Input.GetMouseButton(FireButton))
            {
                if (_endTime > 0)
                {
                    _circle.transform.localScale *= _prefabScale;
                    _endTime -= Time.deltaTime;
                    _scaleTime = _timeToScaleBullet;
                    _bulletScale += (Time.deltaTime / 100);
                    _circle.Damage += (Time.deltaTime * 1.5f);
                    Debug.Log(_circle.Damage);

                }
            }
            
            else if(_circle && _scaleTime > 0)
            {
                _circle.transform.localScale *= _bulletScale;
                _scaleTime -= Time.deltaTime;
                
            }
            else if(_circle)
            {
                Destroy(_circle.gameObject);
            }

        }

        protected override void Shoot()
        {
            if (_circle)
            {
                Destroy(_circle.gameObject);
            }
            _circle = SpawnBullet(_circlePrefab);
            _circle.Offset = Offset;
        }

       
    }
}