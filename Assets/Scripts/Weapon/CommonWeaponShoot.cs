using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Weapon;

public class CommonWeaponShoot : WeaponShoot
{
    protected override float BulletSpeed => _bulletSpeed;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private CommonBullet _bulletPrefab;

    protected override void Shoot()
    {
        CommonBullet bullet = Instantiate(_bulletPrefab, transform.position + Offset, Quaternion.identity);
        bullet.Damage = Damage;
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * BulletSpeed;
    }
}
