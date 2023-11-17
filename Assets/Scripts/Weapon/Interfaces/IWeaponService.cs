using System.Collections.Generic;

namespace Weapon
{
    public interface IWeaponService
    {
        public List<BaseWeapon> GetWeapons { get; }
        public List<BaseWeapon> AvailableWeapons { get; }
        public BaseWeapon ActiveWeapon { get; }
        public int AmountWeapons { get; }
        
        public void ActivateWeapon(WeaponType type);
        public void TakeWeapon(WeaponType type);

        public BaseWeapon GetWeapon(WeaponType type);

    }
}