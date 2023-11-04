using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float HealthPoint { get; }

    public void TakeDamage( float damage);
}