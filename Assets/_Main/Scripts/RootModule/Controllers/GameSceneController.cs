using System;
using ComponentsModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class GameSceneController : IInitializable, IDisposable
    {
        private readonly GameObject _menu;
        private readonly PlayerProvider _player;

        public GameSceneController(GameObject menu, PlayerProvider player)
        {
            _menu = menu;
            _player = player;
        }

        public void Initialize()
        {
            _player.Get<IHealthComponent>().Died += OnPlayerDied;
        }

        public void Dispose()
        {
            _player.Get<IHealthComponent>().Died -= OnPlayerDied;
        }

        private void OnPlayerDied() => _menu.SetActive(true);
    }
}