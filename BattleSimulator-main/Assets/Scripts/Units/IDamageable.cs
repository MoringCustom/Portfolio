using UnityEngine;

namespace BS.Units
{
    public interface IDamageable
    {
        public int Health { get; }
        public bool IsEnemy { get; }

        public void TakeDamage(int damage);

        public void Hit(Vector3 force, Vector3 position);
    }
}