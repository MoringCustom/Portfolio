using System.Collections.Generic;
using BS.Units;
using UnityEngine;

namespace BS.Environment
{
    public class Lava : Trap
    {
        [SerializeField] private int _damage = 3;
        [SerializeField] private float _delay = 0.5f;

        private List<IDamageable> _units = new List<IDamageable>();
        private float _delayCounter;

        private void Update()
        {
            if (_delayCounter > 0)
                _delayCounter -= Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable unit) && !_units.Contains(unit))
                _units.Add(unit);
        }

        private void OnTriggerStay(Collider other)
        {
            if (_delayCounter > 0)
                return;

            foreach (var unit in _units)
                unit.TakeDamage(_damage);

            _delayCounter = _delay;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDamageable unit))
                _units.Remove(unit);
        }
    }
}