using ComponentsModule;
using UnityEngine;
using Zenject;

namespace CoinsModule
{
    public class CoinInstaller : MonoInstaller
    {
        [SerializeField] private GameObject coinObject;
        [SerializeField] private int value;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>()
                .FromInstance(coinObject)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Coin>()
                .AsSingle()
                .WithArguments(value)
                .NonLazy();
        }
    }
}