using System.Collections.Generic;
using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    public class Grenade : Bomb
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _radius;
        [SerializeField] private float _force;
        [SerializeField] private ParticleSystem _explosionEffect;

        protected override void Explode()
        {
            List<IDamageable> targets = new List<IDamageable>();
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            base.Explode();
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);

            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.TryGetComponent(out IDamageable target) && !targets.Contains(target))
                {
                    targets.Add(target);
                    target.TakeDamage(_damage);
                    target.Hit(Vector3.up * _force, transform.position);
                }
            }

            Push();
        }
    }
}