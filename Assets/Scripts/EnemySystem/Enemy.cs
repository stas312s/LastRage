using System;
using System.Collections;
using System.Collections.Generic;
using HealthSystem;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageTaker<CommonBullet>
{
    [SerializeField] private Transform _target;
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
        if (_target != null)
        {
            Vector2 direction = _target.position - transform.position;
            direction.Normalize();
            direction.y = 0;
            Vector2 Move = new Vector2(direction.x * speed * Time.deltaTime, direction.y); 
            _rb.velocity = (Move);
        }
    }

   
}
