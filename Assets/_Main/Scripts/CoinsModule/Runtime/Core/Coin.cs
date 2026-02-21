using ComponentsModule;
using UnityEngine;

namespace CoinsModule
{
    public class Coin : IDestroyable
    {
        private readonly GameObject _gameObject;
        private readonly int _value;

        public Coin(int value, GameObject gameObject)
        {
            _value = value;
            _gameObject = gameObject;
        }

        public int Value => _value;

        public void Destroy() => Object.Destroy(_gameObject);
    }
}