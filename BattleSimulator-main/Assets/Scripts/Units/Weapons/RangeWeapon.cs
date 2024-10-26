using UnityEngine;

namespace BS.Units.Weapons
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private Transform _startPoint;

        protected Transform StartPoint => _startPoint;

        public virtual void Shoot(Vector3 targetPosition)
        {
            _startPoint.LookAt(new Vector3(targetPosition.x, _startPoint.position.y, targetPosition.z));
        }
    }
}