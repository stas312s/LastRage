using UnityEngine;

namespace Weapon
{
    public abstract class BaseWeapon: MonoBehaviour
    {
        public abstract WeaponType Type { get; }
        public float Damage { get; }
        public float ShootDelay { get; }
        public bool IsAvailable { get; private set; }
        public bool IsActive { get; set; }
        public abstract Sprite Icon { get; }

        public void TakeWeapon()
        {
            IsAvailable = true;
        }

        public void ActivateWeapon()
        {
            enabled = true;
            IsActive = true;
        }
        
        public void DisactivateWeapon()
        {
            IsActive = false;
            enabled = false;
        }
    }

    public enum WeaponType
    {
        Common,
        Rocket,
        Circle,
        Riffle,
        Multiply
    }
}