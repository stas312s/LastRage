using System;
using System.Security.Cryptography.X509Certificates;
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
            
            //CheckCircle();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var activeWeaponType = _weaponService.ActiveWeapon.Type.Previous();
                while (!_weaponService.GetWeapon(activeWeaponType).IsAvailable)
                {
                    activeWeaponType = activeWeaponType.Previous();
                }
                
                if (_weaponService.ActiveWeapon.Type!= WeaponType.Circle)
                {
                    
                    GameObject circleWeaponObject = GameObject.Find("Circle");
                    if (circleWeaponObject != null)
                    {
                        Destroy(circleWeaponObject);
                    }
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

        // private void CheckCircle()
        // {
        //     if (_weaponService.ActiveWeapon.Type != WeaponType.Circle)
        //     {
        //             
        //         GameObject circleWeaponObject = GameObject.Find("Circle(Clone)");
        //         if (circleWeaponObject != null)
        //         {
        //             Destroy(circleWeaponObject);
        //         }
        //     }
        // }
    }
}