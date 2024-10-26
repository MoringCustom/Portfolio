using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    public class PoisonBomb : Bomb
    {
        [SerializeField] private PoisonField _poisonFieldPrefab;

        protected override void Explode()
        {
            base.Explode();

            Instantiate(_poisonFieldPrefab, transform.position, Quaternion.identity);
            Push();
        }
    }
}