using DG.Tweening;
using UnityEngine;

namespace CoinsModule
{
    public class RotationAnimation : MonoBehaviour
    {
        private const float FullAngle = 360f;

        [SerializeField] private float oneLoopDuration = 2f;

        private Tween _tween;

        private void OnEnable()
        {
            _tween = transform.DORotate(new(0f, FullAngle, 0f), oneLoopDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

        private void OnDisable() => _tween?.Kill();
    }
}