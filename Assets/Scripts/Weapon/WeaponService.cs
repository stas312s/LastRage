using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class WeaponService: IWeaponService
    {
        public event Action OnChangeWeapon;
        public List<BaseWeapon> GetWeapons => _weapons;
        public List<BaseWeapon> AvailableWeapons => _weapons.Where(weapon => weapon.IsAvailable).ToList();
        public BaseWeapon ActiveWeapon => _weapons.FirstOrDefault(weapon => weapon.IsActive);
        public int AmountWeapons => _weapons.Count;

        private List<BaseWeapon> _weapons;

        public WeaponService(List<BaseWeapon> weapons)
        {
            _weapons = weapons;
         
            TakeWeapon(WeaponType.Common);
            TakeWeapon(WeaponType.Circle);
            TakeWeapon(WeaponType.Multiply);
            TakeWeapon(WeaponType.Riffle);
            ActivateWeapon(WeaponType.Common);
            
        }
        
        

        public void TakeWeapon(WeaponType type)
        {
            GetWeapon(type).TakeWeapon();
        }

        public BaseWeapon GetWeapon(WeaponType type)
        {
            return _weapons.First(weapon => weapon.Type == type);
        }


        public void ActivateWeapon(WeaponType type)
        {
            foreach (var weapon in AvailableWeapons)
            {
                if (weapon.Type == type)
                {
                    weapon.ActivateWeapon();
                }
                else
                {
                    weapon.DisactivateWeapon();
                }
            }

            OnChangeWeapon?.Invoke();
        }
        
        
        
    }
}