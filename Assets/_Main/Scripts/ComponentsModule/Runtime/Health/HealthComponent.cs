using System;
using UnityEngine;

namespace ComponentsModule
{
    public class HealthComponent : IHealthComponent
    {
        private readonly int _maxHealth;

        private int _currentHealth;

        public event Action<int, int> HealthChanged;
        public event Action Died;

        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
        public bool IsAlive => _currentHealth > 0;

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive)
                return;

            _currentHealth -= amount;
            _currentHealth = Mathf.Max(_currentHealth, 0);

            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
                Died?.Invoke();
        }
    }
}