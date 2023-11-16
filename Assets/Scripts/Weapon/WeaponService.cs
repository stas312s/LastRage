using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class WeaponService: IWeaponService
    {


        public List<BaseWeapon> GetWeapons => _weapons;
        public List<BaseWeapon> AvailableWeapons { get; }
        public BaseWeapon EnabledWeapon => _weapons.FirstOrDefault(weapon => weapon.IsActive);

        private List<BaseWeapon> _weapons;

        public WeaponService(List<BaseWeapon> weapons)
        {
            _weapons = weapons;
            foreach (var weapon in _weapons)
            {
                Debug.Log(weapon.name);
            }
        }
        
        
        public void ActivateWeapon(BaseWeapon baseWeapon)
        {
            
        }
        
        
        
    }
}