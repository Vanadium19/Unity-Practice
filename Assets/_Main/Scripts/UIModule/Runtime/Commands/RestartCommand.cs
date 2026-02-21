using CommandsModule;
using Cysharp.Threading.Tasks;
using Zenject;

namespace UIModule
{
    public class RestartCommand : IAsyncCommand
    {
        [Inject] private Menu _menu;

        public UniTask<TaskResult> Execute()
        {
            _menu.Restart();
            return UniTask.FromResult(TaskResult.Success);
        }
    }
}