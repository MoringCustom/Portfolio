using BS.Wallets;
using TMPro;
using UnityEngine;

namespace BS.UI.View
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Wallet _wallet;

        private void OnEnable()
        {
            _wallet.MoneyChanged += ShowMoney;
        }

        private void Start()
        {
            ShowMoney(_wallet.Money);
        }

        private void OnDisable()
        {
            _wallet.MoneyChanged -= ShowMoney;
        }

        private void ShowMoney(int value)
        {
            _text.text = value.ToString();
        }
    }
}