using System;
using Extension;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public class WeaponInputService: MonoBehaviour
    {
        [Inject] private IWeaponService _weaponService;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var activeWeaponType = _weaponService.ActiveWeapon.Type.Previous();
                while (!_weaponService.GetWeapon(activeWeaponType).IsAvailable)
                {
                    activeWeaponType = activeWeaponType.Previous();
                }
                _weaponService.ActivateWeapon(activeWeaponType);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                var activeWeaponType = _weaponService.ActiveWeapon.Type.Next();
                while (!_weaponService.GetWeapon(activeWeaponType).IsAvailable)
                {
                    activeWeaponType = activeWeaponType.Next();
                }
                _weaponService.ActivateWeapon(activeWeaponType);
                
                
            }
        }
    }
}