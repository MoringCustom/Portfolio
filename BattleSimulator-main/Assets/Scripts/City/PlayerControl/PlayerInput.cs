using UnityEngine;

namespace BS.City.PlayerControl
{
    public class PlayerInput : MonoBehaviour
    {
        private readonly string _horizontal = "Horizontal";
        private readonly string _vertical = "Vertical";

        [SerializeField] private Joystick _joystick;

        private Vector3 _moveInput;

        public Vector3 MoveInput => _moveInput;

        private void Update()
        {
            _moveInput = Vector3.right * _joystick.Horizontal + Vector3.forward * _joystick.Vertical;

            if (_moveInput != Vector3.zero)
                return;

            _moveInput = Vector3.right * Input.GetAxis(_horizontal) + Vector3.forward * Input.GetAxis(_vertical);
        }
    }
}