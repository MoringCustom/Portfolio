using BS.Units.Movement;
using UnityEngine;

namespace BS.Environment
{
    public class Dirt : Trap
    {
        [SerializeField] private float _decelerationFactor = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BotMovementSource movementSource))
                movementSource.DivideSpeed(_decelerationFactor);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BotMovementSource movementSource))
                movementSource.ResetSpeed();
        }
    }
}