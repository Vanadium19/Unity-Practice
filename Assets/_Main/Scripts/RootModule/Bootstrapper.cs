using PlayerModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class Bootstrapper : MonoInstaller
    {
        [SerializeField] private PlayerProvider player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerProvider>()
                .FromInstance(player)
                .AsSingle();

            Container.Bind<HealPlayerCommand>()
                .AsSingle()
                .NonLazy();
        }
    }
}