using System;
using System.Collections;
using System.Collections.Generic;
using HealthSystem;
using Player.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageTaker<CommonBullet>
{
    [Inject] private IPlayerPosition _playerPosition;
    
    public int Damage = 1;
    
    [SerializeField] protected float _speed = 10f;
   
    [SerializeField] private float _stopDistance = 8f;
    
    protected Rigidbody2D _rb;

    private bool _isFlip = false;
    private Coroutine _stop;
    private Collider2D _collider2D;
    private bool _isGround = false;
    
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        
    }
    
    private void FixedUpdate()
    {
        MonstrMove();
        GravityFall();
    }

    protected virtual void MonstrMove()
    {
        if (_playerPosition.Transform != null && _stop == null)
        {
            Vector2 direction = _playerPosition.Position - (Vector2)transform.position;
            float distance = direction.magnitude;
            direction.Normalize();
            direction.y = 0;
            if (distance > _stopDistance)
            {
                Vector2 Move = new Vector2(direction.x * _speed * Time.deltaTime, direction.y); 
                _rb.velocity = (Move);
            }
            else
            {
                _stop = StartCoroutine(MoveWait());
            }
            
        }
       
    }

    private void GravityFall()
    {
        if (!IsGrounded())
        {
            _rb.gravityScale = 30;
        }
        else
        {
            _rb.gravityScale = 1;
        }
    }

    private bool IsGrounded()
    {
        Vector3 center = _collider2D.bounds.center;
        Vector3 centerRight = new Vector3(center.x +0.5f, center.y, center.z);
        Vector3 centerLeft = new Vector3(center.x -0.5f, center.y, center.z);
        
        RaycastHit2D hit = PlayerRayGround(centerRight);
        RaycastHit2D hit2 = PlayerRayGround(centerLeft);
        return hit.collider != null || hit2.collider != null;
    }
    
    private RaycastHit2D PlayerRayGround(Vector3 origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down,
            _collider2D.bounds.extents.y + 0.1f, LayerMask.GetMask("Ground"));
        return hit;
    }
    
    private IEnumerator MoveWait()
    {
        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        _stop = null;

    }

    
}
