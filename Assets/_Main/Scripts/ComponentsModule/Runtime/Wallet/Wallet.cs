using System;

namespace ComponentsModule
{
    public class Wallet : IWallet
    {
        private int _coins;

        public event Action<int> CoinsChanged;

        public int Coins => _coins;

        public void AddCoins(int amount)
        {
            if (amount <= 0)
                return;

            _coins += amount;
            CoinsChanged?.Invoke(_coins);
        }

        public void RemoveCoins(int amount)
        {
            if (amount <= 0)
                return;

            _coins -= amount;
            CoinsChanged?.Invoke(_coins);
        }

        public bool HaveCoins(int amount) => _coins >= amount;
    }
}