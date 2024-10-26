using System.Collections.Generic;
using BS.Environment;
using UnityEngine;

namespace BS.Level
{
    public class TrapsSpawner : MonoBehaviour
    {
        [SerializeField] private Trap[] _trapsPrefab;
        [SerializeField] private int _trapsSpawnedCount;

        private List<Transform> _spawnPoints = new List<Transform>();
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            AddSpawnPoints();
        }

        private void Start()
        {
            SpawnTraps();
        }

        private void AddSpawnPoints()
        {
            for (int i = 0; i < _transform.childCount; i++)
                _spawnPoints.Add(_transform.GetChild(i));
        }

        private void SpawnTraps()
        {
            for (int i = 0; i < _trapsSpawnedCount; i++)
                SpawnTrap();
        }

        private void SpawnTrap()
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

            Instantiate(_trapsPrefab[Random.Range(0, _trapsPrefab.Length)], spawnPoint);
            _spawnPoints.Remove(spawnPoint);
        }
    }
}