using UnityEngine;

namespace Weapon
{
    public abstract class BaseWeapon: MonoBehaviour
    {
        public float Damage { get; }
        public float ShootDelay { get; }
        public bool IsActive { get; set; }
    }
}