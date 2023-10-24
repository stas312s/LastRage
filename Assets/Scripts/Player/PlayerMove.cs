using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider2D;
    private Vector2 _movement;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y);
            _rb.velocity = (direction);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        int jumpLayer = LayerMask.GetMask("Ground", "Enemy");
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.down,
            _collider2D.bounds.extents.y + extraHeight, jumpLayer);
        
    return hit.collider != null;
    }
    
    
   

    
}
