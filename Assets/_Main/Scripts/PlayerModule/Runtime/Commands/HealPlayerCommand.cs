using CommandsModule;
using ComponentsModule;
using Cysharp.Threading.Tasks;

namespace PlayerModule
{
    public class HealPlayerCommand : IAsyncCommand<PlayerProvider, int, int>
    {
        public UniTask<TaskResult> Execute(PlayerProvider player, int amount, int cost)
        {
            var wallet = player.Get<IWallet>();

            if (!wallet.HaveCoins(cost))
                return UniTask.FromResult(TaskResult.Failure);

            var health = player.Get<IHealthComponent>();

            if (health.CurrentHealth >= health.MaxHealth)
                return UniTask.FromResult(TaskResult.Failure);

            health.Heal(amount);
            wallet.RemoveCoins(cost);
            return UniTask.FromResult(TaskResult.Success);
        }
    }
}