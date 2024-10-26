using BS.Environment;
using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    [RequireComponent(typeof(MeleeWeapon))]
    public class Arrow : Projectile
    {
        private MeleeWeapon _weapon;

        private void OnEnable()
        {
            if (_weapon == null)
                _weapon = GetComponent<MeleeWeapon>();

            _weapon.Hited += Push;
        }

        private void Start()
        {
            _weapon.SetBattleSide(IsEnemy);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Ground ground))
                Push();
        }

        private void OnDisable()
        {
            _weapon.Hited -= Push;
        }
    }
}