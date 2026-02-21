using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DoorModule
{
    public class DoorAnimation : MonoBehaviour
    {
        [SerializeField] private Transform leftDoor;
        [SerializeField] private Transform rightDoor;

        [SerializeField] private float angle;
        [SerializeField] private float duration;

        private Tween _tween;

        [Button]
        public void Open()
        {
            _tween?.Kill();

            var sequence = DOTween.Sequence();

            sequence.Join(leftDoor.DOLocalRotate(new(0, angle), duration))
                .Join(rightDoor.DOLocalRotate(new(0, -angle), duration))
                .OnComplete(EndAnimation);

            _tween = sequence.Play();
        }

        [Button]
        public void Close()
        {
            _tween?.Kill();

            var sequence = DOTween.Sequence();

            sequence.Join(leftDoor.DOLocalRotate(Vector2.zero, duration))
                .Join(rightDoor.DOLocalRotate(Vector2.zero, duration))
                .OnComplete(EndAnimation);

            _tween = sequence.Play();
        }

        private void EndAnimation() => _tween = null;
    }
}