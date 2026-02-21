using UnityEngine;

namespace CommonModule
{
    public static class AnimationParam
    {
        public static readonly int IsWalking = Animator.StringToHash("IsWalking");
        public static readonly int IsFalling = Animator.StringToHash("IsFalling");
        public static readonly int Jumped = Animator.StringToHash("Jumped");
    }
}