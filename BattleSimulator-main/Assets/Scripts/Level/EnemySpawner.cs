using System.Collections.Generic;
using BS.Level.LevelsConfig;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Level
{
    public class EnemySpawner : MonoBehaviour
    {
        private readonly Quaternion _unitAngle = Quaternion.Euler(0, 270, 0);

        [SerializeField] private Transform _targetParent;
        [SerializeField] private Button _startButton;

        private IReadOnlyList<UnitConfig> _unitsConfig;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Initialize(IReadOnlyList<UnitConfig> unitsConfig)
        {
            _unitsConfig = unitsConfig;
        }

        public void Spawn()
        {
            foreach (var unitConfig in _unitsConfig)
            {
                foreach (var position in unitConfig.Positions)
                {
                    var unit = Instantiate(unitConfig.UnitPrefab, position, _unitAngle, _transform);
                    unit.Init(true, _targetParent, _startButton);
                }
            }
        }
    }
}