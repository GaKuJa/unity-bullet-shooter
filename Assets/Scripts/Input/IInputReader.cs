using UnityEngine;

namespace Shooter.Input
{
    public interface IInputReader
    {
        Vector2 MoveDirection { get; }
        bool IsFiring { get; }
    }
}
