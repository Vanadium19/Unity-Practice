using CommandsModule;
using Cysharp.Threading.Tasks;
using Zenject;

namespace UIModule
{
    public class ExitCommand : IAsyncCommand
    {
        [Inject] private Menu _menu;

        public UniTask<TaskResult> Execute()
        {
            _menu.Exit();
            return UniTask.FromResult(TaskResult.Success);
        }
    }
}