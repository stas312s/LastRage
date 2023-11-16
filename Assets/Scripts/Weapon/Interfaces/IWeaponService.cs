using System.Collections.Generic;

namespace Weapon
{
    public interface IWeaponService
    {
        public List<BaseWeapon> GetWeapons { get; }
        public List<BaseWeapon> AvailableWeapons { get; }
        public BaseWeapon EnabledWeapon { get; }
        
        public void ActivateWeapon(BaseWeapon baseWeapon);
        
    }
}