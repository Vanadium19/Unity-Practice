using ComponentsModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementController : ITickable
    {
        private readonly IMoveComponent _mover;
        private readonly IRotationComponent _rotation;
        private readonly IInputMap _inputMap;

        public PlayerMovementController(IMoveComponent mover,
            IRotationComponent rotation,
            IInputMap inputMap)
        {
            _mover = mover;
            _inputMap = inputMap;
            _rotation = rotation;
        }

        public void Tick()
        {
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