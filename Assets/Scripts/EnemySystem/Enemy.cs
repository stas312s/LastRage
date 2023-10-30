using System;
using System.Collections;
using System.Collections.Generic;
using HealthSystem;
using Player.Interfaces;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageTaker<CommonBullet>
{
    [Inject] private IPlayerPosition _playerPosition;
    [SerializeField] private float speed = 10f;
    
    private Rigidbody2D _rb;
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        MonstrMove();
    }

    private void MonstrMove()
    {
        if (_playerPosition.Transform != null)
        {
            Vector2 direction = _playerPosition.Position - (Vector2)transform.position;
            direction.Normalize();
            direction.y = 0;
            Vector2 Move = new Vector2(direction.x * speed * Time.deltaTime, direction.y); 
            _rb.velocity = (Move);
        }
    }

   
}
