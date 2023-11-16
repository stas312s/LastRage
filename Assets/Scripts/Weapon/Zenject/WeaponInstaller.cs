using System.Collections.Generic;
using System.ComponentModel;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Weapon.Zenject
{
    public class WeaponInstaller: MonoInstaller
    {
        [SerializeField] private List<BaseWeapon> _weapons;
        public override void InstallBindings()
        {
            var weaponService = new WeaponService(_weapons);
            Container
                .BindInterfacesTo<WeaponService>()
                .FromInstance(weaponService)
                .AsSingle();
        }
    }
}