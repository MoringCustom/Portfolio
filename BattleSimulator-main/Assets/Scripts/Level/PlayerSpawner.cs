using System;
using System.Collections.Generic;
using BS.Units;
using BS.Wallets;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Level
{
    public class PlayerSpawner : MonoBehaviour
    {
        private readonly Quaternion _unitAngle = Quaternion.Euler(0, 90, 0);

        [SerializeField] private Wallet _wallet;
        [SerializeField] private Button _startButton;
        [SerializeField] private Transform _targetParent;

        private Unit _unitPrefab;
        private Transform _transform;
        private int _maxSpawnUnitCount;
        private List<Unit> _units = new List<Unit>();

        public event Action<int> UnitsCountChanged;

        public int MaxSpawnCount => _maxSpawnUnitCount;

        private void Awake()
        {
            _transform = transform;
        }

        public void Initialize(int maxSpawnUnitCount)
        {
            _maxSpawnUnitCount = maxSpawnUnitCount;

            UnitsCountChanged?.Invoke(_units.Count);
        }

        public void Spawn(Vector3 position)
        {
            if (_unitPrefab == null)
                return;

            if (_units.Count < _maxSpawnUnitCount && _wallet.CanBuy(_unitPrefab.Price))
                SpawnUnit(position);
        }

        public void SelectUnit(Unit unit)
        {
            _unitPrefab = unit;
        }

        public void Clean()
        {
            foreach (var unit in _units)
                DeleteOneUnit(unit);

            _units.Clear();
            UnitsCountChanged?.Invoke(_units.Count);
        }

        public void RemoveOneUnit(Unit unit)
        {
            DeleteOneUnit(unit);

            _units.Remove(unit);
            UnitsCountChanged?.Invoke(_units.Count);
        }

        private void DeleteOneUnit(Unit unit)
        {
            _wallet.AddMoney(unit.Price);
            Destroy(unit.gameObject);
        }

        private void SpawnUnit(Vector3 position)
        {
            var unit = Instantiate(_unitPrefab, position, _unitAngle, _transform);
            unit.Init(false, _targetParent, _startButton);

            _units.Add(unit);
            _wallet.RemoveMoney(unit.Price);
            UnitsCountChanged?.Invoke(_units.Count);
        }
    }
}