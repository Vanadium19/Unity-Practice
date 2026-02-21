using Zenject;

namespace UIModule
{
    public class UIModuleInstaller : Installer<UIModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Menu>()
                .AsSingle()
                .NonLazy();

            Container.Bind<ExitCommand>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LoadGameCommand>()
                .AsSingle()
                .NonLazy();

            Container.Bind<ReturnToMenuCommand>()
                .AsSingle()
                .NonLazy();

            Container.Bind<RestartCommand>()
                .AsSingle()
                .NonLazy();
        }
    }
}