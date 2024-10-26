using UnityEngine;

namespace BS.Units
{
    public class UnitRemover : MonoBehaviour
    {
        private readonly float _speed = 0.3f;
        private readonly float _removeTime = 5f;

        private float _timeCounter = 0f;

        private void Update()
        {
            if (_timeCounter <= 0)
                return;

            _timeCounter -= Time.deltaTime;
            Move();
        }

        public void StartRemove()
        {
            _timeCounter = _removeTime;
        }

        private void Move()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    }
}