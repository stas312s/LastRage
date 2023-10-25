using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider2D;
    private Vector2 _movement;
    private bool _canMove = false;
    private bool _canJump = false;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
       ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_canMove && !IsWall())
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime, _rb.velocity.y);
            _rb.velocity = (direction);
        }

        if (_canJump && IsGrounded())
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    private void ReadInput()
    {
        _canMove = Input.GetButton("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            _canJump = true;
        }
    }

    private bool IsWall()
    {
        Vector3 top = _collider2D.bounds.max;
        Vector3 centr = top + Vector3.down;
        Vector3 down = top + Vector3.down * 2;
       
        RaycastHit2D hit = Physics2D.Raycast(down, Vector2.right,
            _collider2D.bounds.extents.x + 0.2f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit2 = Physics2D.Raycast(centr, Vector2.right,
            _collider2D.bounds.extents.x + 0.2f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit3 = Physics2D.Raycast(top, Vector2.right,
            _collider2D.bounds.extents.x + 0.2f, LayerMask.GetMask("Ground"));
        return hit.collider != null || hit2.collider != null || hit3.collider != null;
    }
    private bool IsGrounded()
    {
        Vector3 center = _collider2D.bounds.center;
        Vector3 centerRight = new Vector3(center.x +0.5f, center.y, center.z);
        Vector3 centerLeft = new Vector3(center.x -0.5f, center.y, center.z);
        
        int jumpLayer = LayerMask.GetMask("Ground", "Enemy");
        float extraHeight = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(centerRight, Vector2.down,
            _collider2D.bounds.extents.y + extraHeight, jumpLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(centerLeft, Vector2.down,
            _collider2D.bounds.extents.y + extraHeight, jumpLayer);
        
        return hit.collider != null || hit2.collider != null;
    }
    
    
   

    
}
