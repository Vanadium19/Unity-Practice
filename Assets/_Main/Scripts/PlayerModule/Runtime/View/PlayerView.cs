using CommonModule;
using ComponentsModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private IMoveComponent _moveComponent;

        [Inject]
        public void Construct(IMoveComponent moveComponent)
        {
            _moveComponent = moveComponent;
            _moveComponent.Jumped += OnJumped;
        }

        private void OnDestroy()
        {
            _moveComponent.Jumped -= OnJumped;
        }

        private void Update()
        {
            if (_moveComponent == null)
                return;

            animator.SetBool(AnimationParam.IsWalking, _moveComponent.IsRunning);
            animator.SetBool(AnimationParam.IsFalling, _moveComponent.IsFalling);
        }

        private void OnJumped()
        {
            animator.SetTrigger(AnimationParam.Jumped);
        }
    }
}