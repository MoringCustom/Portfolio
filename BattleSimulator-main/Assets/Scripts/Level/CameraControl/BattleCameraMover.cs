using BS.City.PlayerControl;
using UnityEngine;

namespace BS.Level.CameraControl
{
    [RequireComponent(typeof(PlayerInput))]
    public class BattleCameraMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [Header("Positions")]
        [SerializeField] private float _maxPositionX = 40f;
        [SerializeField] private float _minPositionX = -40;
        [SerializeField] private float _maxPositionZ = -25f;
        [SerializeField] private float _minPositionZ = -60f;
        [SerializeField] private float _maxPositionY = 9f;
        [SerializeField] private float _minPositionY = 3.5f;

        private Transform _transform;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _transform = transform;
            _playerInput = GetComponent<PlayerInput>();
        }

        private void LateUpdate()
        {
            Move();
        }

        private void Move()
        {
            _transform.Translate(_playerInput.MoveInput * _speed * Time.deltaTime);

            ClampPosition();
        }

        private void ClampPosition()
        {
            Vector3 clampedPosition = _transform.position;

            clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minPositionX, _maxPositionX);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minPositionY, _maxPositionY);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, _minPositionZ, _maxPositionZ);

            _transform.position = clampedPosition;
        }
    }
}