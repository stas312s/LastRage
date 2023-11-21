using UnityEngine;

namespace Weapon
{
    public abstract class BaseWeapon: MonoBehaviour
    {
        public abstract WeaponType Type { get; }
        public virtual float Damage => 1f;
        public virtual float ShootDelay => 0.1f;
        public bool IsAvailable { get; private set; }
        public bool IsActive { get; set; } 
        public abstract Sprite Icon { get; }

        public void TakeWeapon()
        {
            IsAvailable = true;
        }

        public virtual void ActivateWeapon()
        {
            enabled = true;
            IsActive = true;
        }
        
        public virtual void DisactivateWeapon()
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