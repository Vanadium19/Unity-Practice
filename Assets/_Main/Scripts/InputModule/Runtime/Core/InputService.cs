using UnityEngine;

namespace InputModule
{
    public class InputService : IInputMap
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";

        public bool IsJumpPressed => Input.GetKeyDown(KeyCode.Space);
        public Vector2 MoveInput => GetMoveInput();
        public Vector2 LookInput => GetLookInput();

        public Vector2 GetMoveInput()
            => Vector2.right * Input.GetAxisRaw(Horizontal) + Vector2.up * Input.GetAxisRaw(Vertical);
        
        public Vector2 GetLookInput()
            => Vector2.right * Input.GetAxisRaw(MouseX) + Vector2.up * Input.GetAxisRaw(MouseY);
    }
}