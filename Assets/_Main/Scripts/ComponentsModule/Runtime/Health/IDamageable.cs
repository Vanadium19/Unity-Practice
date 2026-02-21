using UnityEngine;

namespace ComponentsModule
{
    public interface IDamageable
    {
        bool IsAlive { get; }

        void TakeDamage(int amount);
    }
}