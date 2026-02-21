using System;
using ComponentsModule;
using Zenject;

namespace UIModule
{
    public class WalletPresenter : IInitializable, IDisposable
    {
        private readonly IWallet _wallet;
        private readonly TextView _view;

        public WalletPresenter(IWallet wallet, TextView view)
        {
            _wallet = wallet;
            _view = view;

            OnCoinsChanged(_wallet.Coins);
        }

        public void Initialize() => _wallet.CoinsChanged += OnCoinsChanged;

        public void Dispose() => _wallet.CoinsChanged -= OnCoinsChanged;

        private void OnCoinsChanged(int amount) => _view.SetText(amount.ToString());
    }
}