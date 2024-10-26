using BS.StaticData;
using BS.Units;
using UnityEngine;

namespace BS.City.PlayerControl
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(AnimatorController))]
    internal class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _transform;
        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private AnimatorController _animatorController;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();
            _animatorController = GetComponent<AnimatorController>();
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            var direction = _playerInput.MoveInput;

            _transform.LookAt(_transform.position + direction);
            _rigidbody.velocity = direction * _speed;
            SetAnimatorState(direction);
        }

        private void SetAnimatorState(Vector3 direction)
        {
            var state = direction != Vector3.zero ? AnimatorStates.Run : AnimatorStates.Idle;

            _animatorController.SetState(state);
        }
    }
}