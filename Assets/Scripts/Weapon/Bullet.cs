using System;
using System.Collections;
using System.Security.Cryptography;
using ModestTree;
using Player.Interfaces;
using UnityEngine;
using Zenject;


namespace Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet: MonoBehaviour
    {
        [Inject] private IPlayerPosition _playerPosition;
        
        protected Rigidbody2D _rb;
        public bool NeedDestroy = true;
        [HideInInspector]public float Damage;

        private float _distance = 13f;

        private void Start()
        {
            StartCoroutine(DestroyBullet());
            _rb = GetComponent<Rigidbody2D>();

        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<Ground>(out var ground))
            {
                Destroy();
            }
        }

        private void Update()
        {
            if(Vector2.Distance(transform.position, _playerPosition.Position) > (_distance * 2))
            {
                Destroy();
            }
        }


        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2f);
            Destroy();
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}