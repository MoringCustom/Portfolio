using BS.Settings;
using BS.Wallets;
using UnityEngine;

namespace BS.Level
{
    public class LevelSaver : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _wallet;

        private int _levelsCount;
        private int _moneyReward;

        public void Initialize(int levelsCount, int moneyReward)
        {
            _levelsCount = levelsCount;
            _moneyReward = moneyReward;
        }

        public void FinishLevel()
        {
            GameSaver.SetNextLevel(_levelsCount);
            _wallet.AddMoney(_moneyReward);
        }
    }
}