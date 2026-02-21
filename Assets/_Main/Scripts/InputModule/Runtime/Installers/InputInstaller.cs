using UnityEngine;
using Zenject;

namespace InputModule
{
    [CreateAssetMenu(fileName = "InputInstaller", menuName = "_Main/Installers/InputInstaller")]
    public class InputInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputMap>()
                .To<InputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}