using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Weapon
{
    public class TargetRiffle: CommonBullet
    {
        
         [SerializeField] private float _bulletSpeed = 10f;
         [SerializeField] private float _seekRange = 10f;
         [SerializeField] private LayerMask _enemyLayer;
         [SerializeField]private float _startDelay = 0.2f;
         private Transform _target;
      
        
        
        void Update()
        {
            
            if (_target == null)
            {
                FindNearestTarget();
            }


            if (_target != null && _startDelay < 0) 
            {
                
                Vector2 direction = _target.position - transform.position;
                direction.Normalize();
                _rb.velocity = direction * _bulletSpeed;
            }
            else if(_startDelay >= 0)
            {
                _startDelay -= Time.deltaTime;
            }
            
        }

        void FindNearestTarget()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _seekRange, _enemyLayer);

            float closestDistance = _seekRange;
            Transform closestTarget = null;

            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = collider.transform;
                }
            }

            _target = closestTarget;
        }
    }
}