using BS.Units.Weapons.Projectiles;
using UnityEngine;

namespace BS.Units.Weapons
{
    [RequireComponent(typeof(ProjectilesPool))]
    public class Bow : RangeWeapon
    {
        [SerializeField] private float _force;

        private ProjectilesPool _pool;

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
            base.Shoot(targetPosition);

            var arrow = _pool.Pull();
            arrow.gameObject.SetActive(true);
            arrow.Hurl(StartPoint, StartPoint.forward * _force);
        }
    }
}