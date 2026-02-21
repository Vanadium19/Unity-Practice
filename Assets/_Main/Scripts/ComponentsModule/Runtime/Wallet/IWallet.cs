using System;

namespace ComponentsModule
{
    public interface IWallet
    {
        event Action<int> CoinsChanged;
        int Coins { get; }
        void AddCoins(int amount);
        void RemoveCoins(int amount);
        bool HaveCoins(int amount);
    }
}