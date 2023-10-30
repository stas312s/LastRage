using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player.Zenject
{
    public class PlayerInstaller: MonoInstaller
    {
        [SerializeField] private PlayerMove _playerMove;
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerPosition>()
                .FromInstance(_playerMove)
                .AsSingle();
        }
    }
}