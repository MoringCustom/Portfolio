using UnityEngine;

namespace BS.City.PlayerControl
{
    internal class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private int _cameraPositionZ;
        [SerializeField] private int _cameraPositionY;

        private Vector3 _target;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void LateUpdate()
        {
            _target = _player.position;
            _target.z += _cameraPositionZ;
            _target.y += _cameraPositionY;
            _transform.position = _target;
        }
    }
}