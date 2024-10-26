using BS.Environment;
using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    public abstract class Bomb : Projectile
    {
        [SerializeField] private AudioSource _audioEffect;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Ground ground))
                Explode();
        }

        protected virtual void Explode()
        {
            AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
        }
    }
}