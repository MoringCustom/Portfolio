using UnityEngine;

namespace BS.Units.Movement
{
    public class BotMovementSource : MonoBehaviour, IMovementSource
    {
        [SerializeField] private float _speed = 3f;

        private Vector3 _direction;
        private float _currentSpeed;

        public Vector3 Direction => _direction;
        public float Speed => _currentSpeed;

        private void Awake()
        {
            ResetSpeed();
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void ResetSpeed()
        {
            _currentSpeed = _speed;
        }

        public void DivideSpeed(float value)
        {
            _currentSpeed = _speed / value;
        }
    }
}