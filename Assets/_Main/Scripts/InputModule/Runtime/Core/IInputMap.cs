using UnityEngine;

namespace InputModule
{
    public interface IInputMap
    {
        bool IsJumpPressed { get; }
        Vector2 MoveInput { get; }
        Vector2 LookInput { get; }
    }
}