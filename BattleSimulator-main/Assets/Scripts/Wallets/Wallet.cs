using System;
using UnityEngine;

namespace BS.Wallets
{
    public class Wallet : MonoBehaviour
    {
        private int _money;

        public event Action<int> MoneyChanged;

        public int Money => _money;

        public void Initialize(int money)
        {
            _money = money;
            MoneyChanged?.Invoke(_money);
        }

        public virtual void AddMoney(int value)
        {
            _money += value;
            MoneyChanged?.Invoke(_money);
        }

        public bool CanBuy(int price)
        {
            return price <= _money;
        }

        public virtual void RemoveMoney(int price)
        {
            _money -= price;
            MoneyChanged?.Invoke(_money);
        }
    }
}