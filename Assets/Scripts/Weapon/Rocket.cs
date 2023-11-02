using System.Collections;
using ModestTree;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon
{
    public class Rocket: CommonBullet
    {
        [SerializeField] private float _growthSpeed = 4f;
        [SerializeField] private float _destroyDelay = 0.3f;

        private bool _isScaling = false;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<Ground>(out var ground) || other.TryGetComponent<Enemy>(out var enemy))
            {
                if (!_isScaling)
                {
                    _isScaling = true;
                    _rb.velocity = Vector2.zero;
                    StartCoroutine(ScaleAndDestroyCoroutine());
                }

            }

        }
        
        private IEnumerator ScaleAndDestroyCoroutine()
        {
            Debug.Log("StartScaling");
            float endTime = Time.time + _destroyDelay;

            while (Time.time < endTime)
            {
                Debug.Log("Process Scaling");
                transform.localScale *= 1 + _growthSpeed * Time.deltaTime;
                yield return null;
            }

            Debug.Log("End Scaling");
            Destroy(gameObject);
            
        }
    }
}