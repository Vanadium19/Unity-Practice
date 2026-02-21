using ComponentsModule;
using EntityModule;
using UnityEngine;

namespace RootModule
{
    public class KillZone : MonoBehaviour
    {
        private const int Damage = 1000;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out IDamageable target))
                return;

            target.TakeDamage(Damage);
        }
    }
}