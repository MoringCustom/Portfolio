using BS.Units.Weapons.Projectiles;
using UnityEngine;

namespace BS.Units.Weapons
{
    [RequireComponent(typeof(ProjectilesPool))]
    public class Slingshot : RangeWeapon
    {
        private readonly float _range = 10f;
        private readonly float _minHeight = 0f;
        private readonly float _maxHeight = 3f;

        private Thrower _thrower = new Thrower();
        private ProjectilesPool _pool;
        private float _currentHeight;

        private void Awake()
        {
            _pool = GetComponent<ProjectilesPool>();
        }

        private void Start()
        {
            _pool.Initialize(IsEnemy);
        }

        public override void Shoot(Vector3 targetPosition)
        {
            SetHeight(targetPosition);
            var velocity = _thrower.CalculateVelocityByHeight(StartPoint.position, targetPosition, _currentHeight);
            var bomb = _pool.Pull();
            bomb.gameObject.SetActive(true);
            bomb.Hurl(StartPoint, velocity);
        }

        private void SetHeight(Vector3 targetPosition)
        {
            float lerpFactor = Vector3.Distance(transform.position, targetPosition) / _range;

            _currentHeight = Mathf.Lerp(_minHeight, _maxHeight, lerpFactor);
        }
    }
}