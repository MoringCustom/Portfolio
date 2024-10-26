using UnityEngine;

namespace BS.Units.Movement
{
    public interface IMovementSource
    {
        public Vector3 Direction { get; }
        public float Speed { get; }
    }
}