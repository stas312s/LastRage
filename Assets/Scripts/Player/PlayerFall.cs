using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFall : MonoBehaviour
{
    private float _normalGravity = 1f;
    private float _increasedGravity = 2f;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FallPlayer();
    }

    private void FallPlayer()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _rb.gravityScale = _increasedGravity;
        }
        else
        {
            _rb.gravityScale = _normalGravity;
        }
    }
}
