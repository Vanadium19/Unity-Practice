using CommandsModule;
using Cysharp.Threading.Tasks;
using Zenject;

namespace UIModule
{
    public class LoadGameCommand : IAsyncCommand
    {
        [Inject] private Menu _menu;

        public UniTask<TaskResult> Execute()
        {
            _menu.LoadGame();
            return UniTask.FromResult(TaskResult.Success);
        }
    }
}