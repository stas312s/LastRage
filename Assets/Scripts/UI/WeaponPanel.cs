using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Weapon;
using Zenject;

namespace UI
{
    public class WeaponPanel: MonoBehaviour
    {
        [Inject] private IWeaponService _weaponService;

        [SerializeField] private WeaponIcon _weaponicon;
        [SerializeField] private Transform _parent;

        private List<WeaponIcon> _weaponIcons = new List<WeaponIcon>();
        
        
        private void OnEnable()
        {
            for (int i = 0; i < _weaponService.AmountWeapons; i++)
            {
                
                var icon = Instantiate(_weaponicon, _parent);
                _weaponIcons.Add(icon);
            }
            ReDraw();
            _weaponService.OnChangeWeapon += ReDraw;
        }

        private void OnDisable()
        {
            _weaponService.OnChangeWeapon -= ReDraw;
        }

        private void ReDraw()
        {
            var numberWeapon = 0;
            foreach (WeaponType type in Enum.GetValues(typeof(WeaponType)))
            {
                var weapon = _weaponService.GetWeapon(type);
             
                _weaponIcons[numberWeapon].Activate(weapon.IsActive);
                
                if (weapon.IsAvailable)
                {
                    _weaponIcons[numberWeapon].SetSprite(weapon.Icon);
                }

                numberWeapon++;
            }

        }
        
        
        
    }
}