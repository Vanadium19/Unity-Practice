using System;
using UnityEngine;

namespace ComponentsModule
{
    public interface IHealthComponent : IDamageable
    {
        event Action<int, int> HealthChanged;
        event Action Died;

        int MaxHealth { get; }
        int CurrentHealth { get; }
    }
}