using System.Collections.Generic;
using UnityEngine;

namespace BS.Level.LevelsConfig
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create new Level", order = 51)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _number;
        [SerializeField] private int _levelMoney;
        [SerializeField] private int _moneyReward;
        [SerializeField] private int _maxSpawnUnitCount;
        [SerializeField] private List<UnitConfig> _unitsConfig;

        public int Number => _number;
        public int LevelMoney => _levelMoney;
        public int MoneyReward => _moneyReward;
        public int MaxSpawnUnitCount => _maxSpawnUnitCount;
        public IReadOnlyList<UnitConfig> UnitsConfig => _unitsConfig;
    }
}