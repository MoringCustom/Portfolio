using UnityEngine;

namespace BS.Units.Weapons
{
    public class SpecialWeapon : MeleeWeapon
    {
        private readonly float _attackTime = 1f;

        [SerializeField] private float _delay = 10f;
        [SerializeField] private float _force;

        private float _delayCounter;

        private void Update()
        {
            if (_delayCounter > 0)
                _delayCounter -= Time.deltaTime;
        }

        protected override void Attack(IDamageable target)
        {
            base.Attack(target);

            if (_delayCounter > 0)
                return;

            target.Hit(transform.forward * _force, transform.position);
            Invoke(nameof(SetDelay), _attackTime);
        }

        private void SetDelay()
        {
            _delayCounter = _delay;
        }
    }
}