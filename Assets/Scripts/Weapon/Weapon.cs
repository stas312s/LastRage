using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Vector3 _offset; 
    private int _fireButton = 0;
    
    

    

    private void Update()
    {
        Shoot();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - _shootPoint.position).normalized;
        Debug.Log(mousePosition + " " + direction);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(_fireButton))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position + _offset, Quaternion.identity);

        
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - _shootPoint.position).normalized;

        
           
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * _bulletSpeed;
        }
        
    }
}
