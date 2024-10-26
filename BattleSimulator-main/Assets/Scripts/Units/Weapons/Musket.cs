using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BS.Units.Weapons
{
    public class Musket : RangeWeapon
    {
        private readonly int _penetrationCount = 3;

        [SerializeField] private int _damage;
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private AudioSource _audioEffect;

        public override void Shoot(Vector3 targetPosition)
        {
            base.Shoot(targetPosition);

            _shootEffect.Play();
            AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
            RaycastHit[] hits = Physics.RaycastAll(
                StartPoint.position,
                StartPoint.forward,
                _maxDistance,
                _layerMask,
                QueryTriggerInteraction.Collide);

            CalculateHits(hits);
        }

        private void CalculateHits(RaycastHit[] hits)
        {
            List<IDamageable> targets = new List<IDamageable>();

            var sortedHits = hits.OrderBy(hit => hit.distance);

            foreach (var hit in sortedHits)
            {
                bool canAttack = hit.collider.TryGetComponent(out IDamageable target) &&
                    targets.Contains(target) == false &&
                    target.IsEnemy != IsEnemy;

                if (canAttack)
                {
                    targets.Add(target);
                    target.TakeDamage(_damage);

                    if (targets.Count == _penetrationCount)
                        break;
                }
            }
        }
    }
}