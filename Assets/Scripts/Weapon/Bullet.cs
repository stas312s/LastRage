using System;
using System.Collections;
using ModestTree;
using UnityEngine;


namespace Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet: MonoBehaviour
    {
        protected Rigidbody2D _rb;
        public bool NeedDestroy = true;
        [HideInInspector]public float Damage;

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
        

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2f);
            Destroy();
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
            Debug.Log("GAVGAV");
        }
    }
}