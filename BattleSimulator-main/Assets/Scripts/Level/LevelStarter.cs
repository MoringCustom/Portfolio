using System;
using System.Collections.Generic;
using System.Linq;
using BS.Level.LevelsConfig;
using BS.Settings;
using BS.UI.View;
using BS.Wallets;
using UnityEngine;

namespace BS.Level
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private List<LevelConfig> _levelsConfigs;

        [SerializeField] private Wallet _wallet;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private LevelSaver _levelSaver;
        [SerializeField] private RewardView _rewardView;

        private void Start()
        {
            PrepareLevel();
        }

        private void Initialize(LevelConfig levelConfig)
        {
            _wallet.Initialize(levelConfig.LevelMoney);
            _enemySpawner.Initialize(levelConfig.UnitsConfig);
            _playerSpawner.Initialize(levelConfig.MaxSpawnUnitCount);
            _levelSaver.Initialize(_levelsConfigs.Count, levelConfig.MoneyReward);
            _rewardView.Display(levelConfig.MoneyReward);
        }

        private void PrepareLevel()
        {
            var levelConfig = GetCurrentLevel();

            if (levelConfig == null)
                throw new ArgumentNullException(nameof(LevelConfig));

            Initialize(levelConfig);
            _enemySpawner.Spawn();
        }

        private LevelConfig GetCurrentLevel()
        {
            int levelNumber = Mathf.Min(GameSaver.CurrentLevel, _levelsConfigs.Count);

            return _levelsConfigs.FirstOrDefault(levelConfig => levelConfig.Number == levelNumber);
        }
    }
}