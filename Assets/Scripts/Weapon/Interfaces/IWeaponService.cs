using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Weapon
{
    public interface IWeaponService
    {
        public event Action OnChangeWeapon; 
        public List<BaseWeapon> GetWeapons { get; }
        public List<BaseWeapon> AvailableWeapons { get; }
        public List<BaseWeapon> NotAvailableWeapons { get; }
        public BaseWeapon ActiveWeapon { get; }
        public int AmountWeapons { get; }
        
        public void ActivateWeapon(WeaponType type);
        public void TakeWeapon(WeaponType type);

        public BaseWeapon GetWeapon(WeaponType type);

    }
}