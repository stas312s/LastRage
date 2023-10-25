using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MonstrMove();
    }

    private void MonstrMove()
    {
        if (_target != null)
        {
            
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            direction.y = 0;

            
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
