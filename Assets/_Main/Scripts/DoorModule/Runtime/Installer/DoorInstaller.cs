using UnityEngine;
using Zenject;

namespace DoorModule
{
    public class DoorInstaller : MonoInstaller
    {
        [SerializeField] private DoorAnimation animation;

        public override void InstallBindings()
        {
            Container.Bind<DoorAnimation>()
                .FromInstance(animation)
                .AsSingle();

            Container.Bind<IDoor>()
                .To<Door>()
                .AsSingle()
                .NonLazy();
        }
    }
}