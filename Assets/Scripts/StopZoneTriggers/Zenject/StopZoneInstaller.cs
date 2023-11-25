
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StopZoneTriggers.Zenject
{
    public class StopZoneInstaller: MonoInstaller
    {
        [SerializeField]private List<Transform> _stopPoints;
        public override void InstallBindings()
        {
           var stopZoneService = new StopZoneService();
           stopZoneService.Initialize(_stopPoints);
           Container
               .BindInterfacesTo<StopZoneService>()
               .FromInstance(stopZoneService)
               .AsSingle();
        }
    }
}