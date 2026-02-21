using CoinsModule;
using ComponentsModule;
using EntityModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class CoinCollector : MonoBehaviour
    {
        private IWallet _wallet;

        [Inject]
        public void Construct(IWallet wallet)
        {
            _wallet = wallet;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Coin coin))
                return;

            _wallet.AddCoins(coin.Value);
            coin.Destroy();
        }
    }
}