using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private CommonBullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Vector3 _offset;
    private int _fireButton = 0;
    private float _shootDelay = 0.25f;
    private float _tempTime;

    private void Start()
    {
        _tempTime = Time.time;
    }


    private void Update()
    {
        if (Time.time - _tempTime >= _shootDelay)
        {
            if (Input.GetMouseButtonDown(_fireButton))
            {
                Shoot();
                _tempTime = Time.time;
            }

        }
        
    }

    protected virtual void Shoot()
    {
        CommonBullet bullet = Instantiate(_bulletPrefab, _shootPoint.position + _offset, Quaternion.identity);
        bullet.Damage = _damage;
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - _shootPoint.position).normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * _bulletSpeed;
    }
}
