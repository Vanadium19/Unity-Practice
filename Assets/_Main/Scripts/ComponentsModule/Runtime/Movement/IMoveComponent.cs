using System;
using UnityEngine;

namespace ComponentsModule
{
    public interface IMoveComponent
    {
        event Action Jumped;
        
        bool IsRunning { get; }
        bool IsFalling { get; }

        void Move(Vector2 direction, bool jumpe);
        void SetSpeed(float value);
    }
}