using UnityEngine;

namespace BS.Units.Weapons
{
    [RequireComponent(typeof(IDamageable))]
    public class PoisonEffect : MonoBehaviour
    {
        private readonly float _lifeTime = 5f;
        private readonly float _delay = 1.5f;
        private readonly int _damage = 1;

        private IDamageable _unit;
        private float _delayCounter;

        private void Awake()
        {
            _unit = GetComponent<IDamageable>();
        }

        private void Start()
        {
            Destroy(this, _lifeTime);
        }

        private void Update()
        {
            if (_delayCounter > 0)
                _delayCounter -= Time.deltaTime;

            CauseDamage();
        }

        private void CauseDamage()
        {
            if (_delayCounter > 0)
                return;

            _unit.TakeDamage(_damage);
            _delayCounter = _delay;
        }
    }
}