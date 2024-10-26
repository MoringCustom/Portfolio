using BS.Settings;
using BS.YandexLeaderboard;
using UnityEngine;

namespace BS.Wallets
{
    [RequireComponent(typeof(YandexLeaderboardScoreSetter))]
    public class PlayerWallet : Wallet
    {
        private YandexLeaderboardScoreSetter _leaderboardScoreSetter;

        private void Awake()
        {
            _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();
        }

        private void Start()
        {
            Initialize(GameSaver.Money);
        }

        public override void AddMoney(int value)
        {
            base.AddMoney(value);

            SetScore(value);
            GameSaver.SetMoney(Money);
        }

        public override void RemoveMoney(int price)
        {
            base.RemoveMoney(price);

            GameSaver.SetMoney(Money);
        }

        private void SetScore(int addedValue)
        {
            GameSaver.SetScore(addedValue);

#if UNITY_WEBGL && !UNITY_EDITOR
        _leaderboardScoreSetter.SetPlayerScore(GameSaver.Score);
#endif
        }
    }
}