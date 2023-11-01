using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Weapon;

public class CommonWeaponShoot : WeaponShoot
{
    
    [SerializeField]private CommonBullet _bulletPrefab;

    protected override void Shoot()
    {
        CommonBullet bullet = Instantiate(_bulletPrefab, transform.position + _offset, Quaternion.identity);
        bullet.Damage = _damage;
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * _bulletSpeed;
    }
}
