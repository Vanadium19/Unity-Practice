using CommandsModule;
using Cysharp.Threading.Tasks;
using Zenject;

namespace UIModule
{
    public class ReturnToMenuCommand : IAsyncCommand
    {
        [Inject] private Menu _menu;

        public UniTask<TaskResult> Execute()
        {
            _menu.ReturnToMenu();
            return UniTask.FromResult(TaskResult.Success);
        }
    }
}