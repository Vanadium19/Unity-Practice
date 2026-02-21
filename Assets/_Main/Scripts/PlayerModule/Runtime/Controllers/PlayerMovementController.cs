using ComponentsModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementController : ITickable
    {
        private readonly IMoveComponent _mover;
        private readonly IHealthComponent _health;
        private readonly IRotationComponent _rotation;

        private readonly IInputMap _inputMap;

        public PlayerMovementController(IMoveComponent mover,
            IRotationComponent rotation,
            IHealthComponent health,
            IInputMap inputMap)
        {
            _mover = mover;
            _health = health;
            _rotation = rotation;
            _inputMap = inputMap;
        }

        public void Tick()
        {
            if (!_health.IsAlive)
                return;

            Move();
            Rotate();
        }

        private void Move()
        {
            var jumped = _inputMap.IsJumpPressed;
            var direction = _inputMap.MoveInput;
            _mover.Move(direction, jumped);
        }

        private void Rotate()
        {
            var direction = _inputMap.LookInput;
            _rotation.Rotate(direction);
        }
    }
}