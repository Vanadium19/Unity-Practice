using ComponentsModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerView : MonoBehaviour
    {
        private static readonly int _isWalking = Animator.StringToHash("isWalking");

        [SerializeField] private Animator animator;

        private IMoveComponent _moveComponent;

        [Inject]
        public void Construct(IMoveComponent moveComponent)
        {
            _moveComponent = moveComponent;
        }

        private void Update()
        {
            animator.SetBool(_isWalking, _moveComponent.IsRunning);
        }
    }
}