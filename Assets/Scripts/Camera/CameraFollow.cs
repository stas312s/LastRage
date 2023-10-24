using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;
    
    void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if(_target == null) return;

        Vector2 desiredPosition = new Vector2(_target.position.x, _target.position.y);
        Vector2 smoothedPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y),
            desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
