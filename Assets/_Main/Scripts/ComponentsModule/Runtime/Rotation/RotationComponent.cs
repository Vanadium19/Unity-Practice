using UnityEngine;

namespace ComponentsModule
{
    public class RotationComponent : IRotationComponent
    {
        private readonly Transform _transform;
        private readonly Transform _cameraTransform;

        private readonly float _mouseSensitivity;
        private readonly float _lookMaxX;
        private readonly float _lookMinX;

        private float _rotationX;
        private float _rotationY;

        public RotationComponent(Transform transform, float mouseSensitivity, float lookMaxX, float lookMinX)
        {
            _transform = transform;
            _cameraTransform = Camera.main!.transform;

            _rotationY = _transform.eulerAngles.y;

            _mouseSensitivity = mouseSensitivity;
            _lookMaxX = lookMaxX;
            _lookMinX = lookMinX;
        }

        public void Rotate(Vector2 direction)
        {
            _rotationX += -direction.y * _mouseSensitivity;
            _rotationX = Mathf.Clamp(_rotationX, _lookMinX, _lookMaxX);

            _rotationY += direction.x * _mouseSensitivity;

            _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            _transform.rotation = Quaternion.Euler(0, _rotationY, 0);
        }
    }
}