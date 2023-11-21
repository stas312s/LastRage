using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Weapon;

public class CommonWeaponShoot : WeaponShoot<CommonBullet>
{
    public override WeaponType Type => WeaponType.Common;
    protected override float BulletSpeed => _bulletSpeed;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private CommonBullet _bulletPrefab;

    protected override void Shoot()
    {
        var bullet = SpawnBullet(_bulletPrefab);
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        direction = direction.normalized;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        rb.velocity = direction * BulletSpeed;
        Debug.Log(direction );
    }

    
}
