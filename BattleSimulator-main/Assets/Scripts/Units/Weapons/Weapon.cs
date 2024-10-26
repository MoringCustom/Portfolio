using UnityEngine;

namespace BS.Units.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        private bool _isEnemy;

        protected bool IsEnemy => _isEnemy;

        public void SetBattleSide(bool isEnemy)
        {
            _isEnemy = isEnemy;
        }
    }
}