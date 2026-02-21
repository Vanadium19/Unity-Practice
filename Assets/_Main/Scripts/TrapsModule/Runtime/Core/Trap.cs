using System.Collections.Generic;
using ComponentsModule;
using EntityModule;
using UnityEngine;

namespace TrapsModule
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private float interval;
        [SerializeField] private int damage;

        private readonly List<IDamageable> targets = new();

        private float _lastAttackTime;

        private void Update() => Attack();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out IDamageable damageable))
                return;

            if (targets.Contains(damageable))
                return;

            targets.Add(damageable);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out IDamageable damageable))
                return;

            targets.Remove(damageable);
        }

        private void Attack()
        {
            if (targets.Count == 0)
                return;

            if (_lastAttackTime + interval > Time.time)
                return;

            foreach (var target in targets)
                target.TakeDamage(damage);

            _lastAttackTime = Time.time;
        }
    }
}