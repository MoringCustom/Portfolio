using UnityEngine;

namespace Assets.Scripts.Car
{
    public class WheelRotator : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheelsModels;
        [SerializeField] private Movement _movement;

        private Vector3 _direction = new Vector3(1, 0, 0);

        private void Update()
        {
            if (_movement.IsMoving)
            {
                foreach (Transform wheel in _wheelsModels)
                {
                    wheel.transform.Rotate(_direction * _movement.Speed);
                }
            }
        }
    }
}