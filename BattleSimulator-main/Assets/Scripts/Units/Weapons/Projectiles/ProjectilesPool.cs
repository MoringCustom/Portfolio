using System.Collections.Generic;
using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    public class ProjectilesPool : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;

        private Queue<Projectile> _spawnQueue = new Queue<Projectile>();
        private bool _isEnemy;

        public void Initialize(bool isEnemy)
        {
            _isEnemy = isEnemy;
        }

        public void Push(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _spawnQueue.Enqueue(projectile);
        }

        public Projectile Pull()
        {
            if (_spawnQueue.Count == 0)
                return CreateProjectile();

            return _spawnQueue.Dequeue();
        }

        private Projectile CreateProjectile()
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.Initialize(this, _isEnemy);
            return projectile;
        }
    }
}