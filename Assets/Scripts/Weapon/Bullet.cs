using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class Bullet: MonoBehaviour
    {
        [HideInInspector]public int Damage;

        private void Start()
        {
            StartCoroutine(DestroyBullet());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<Ground>(out var ground))
            {
                Destroy(gameObject);
                
            }
        }
        

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}