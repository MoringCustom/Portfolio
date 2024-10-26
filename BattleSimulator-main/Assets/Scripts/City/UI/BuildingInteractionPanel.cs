using BS.City.PlayerControl;
using BS.Wallets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BS.City.UI
{
    internal class BuildingInteractionPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _buttonPay;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private TMP_Text _textPrice;

        private BuildingInteraction _currentBuilding;

        private void OnEnable()
        {
            _player.Entered += Activate;
            _player.Gone += Disable;
        }

        private void OnDisable()
        {
            _player.Entered -= Activate;
            _player.Gone -= Disable;
        }

        private void Activate(BuildingInteraction buildingInteraction)
        {
            _panel.SetActive(true);
            _currentBuilding = buildingInteraction;
            _textPrice.text = buildingInteraction.Price.ToString();
            _buttonPay.onClick.AddListener(Buy);
        }

        private void Disable()
        {
            _panel.SetActive(false);
            _buttonPay.onClick.RemoveListener(Buy);
        }

        private void Buy()
        {
            if (_wallet.CanBuy(_currentBuilding.Price))
            {
                _wallet.RemoveMoney(_currentBuilding.Price);
                _currentBuilding.Unlock();
            }

            Disable();
        }
    }
}