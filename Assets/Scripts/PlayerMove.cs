using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private float _speed = 10f; 
    [SerializeField] private float _jumpForce = 10f;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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

        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
   

    
}
