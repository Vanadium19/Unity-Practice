using UIModule;
using Zenject;

namespace RootModule
{
    public class Bootstrapper : MonoInstaller
    {
        public override void InstallBindings()
        {
            UIModuleInstaller.Install(Container);
        }
    }
}