using DoorModule;
using EntityModule;
using UnityEngine;

namespace PlayerModule
{
    public class DoorController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out IDoor door))
                return;

            door.Open();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out IDoor door))
                return;

            door.Close();
        }
    }
}