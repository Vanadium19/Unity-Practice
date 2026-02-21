using PlayerModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerProvider player;
        [SerializeField] private GameObject menu;

        public override void InstallBindings()
        {
            Container.Bind<PlayerProvider>()
                .FromInstance(player)
                .AsSingle();

            Container.Bind<HealPlayerCommand>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GameSceneController>()
                .AsSingle()
                .WithArguments(menu)
                .NonLazy();
        }
    }
}