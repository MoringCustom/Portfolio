using System;
using UnityEngine;

namespace BS.Units.Weapons
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private int _damage;
        [SerializeField] private ParticleSystem _strikeEffect;
        [SerializeField] private AudioSource _audioEffect;

        public event Action Hited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable target) && target.IsEnemy != IsEnemy)
                Attack(target);
        }

        protected virtual void Attack(IDamageable target)
        {
            target.TakeDamage(_damage);
            _strikeEffect.Play();
            AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
            Hited?.Invoke();
        }
    }
}