using System;
using BS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Advertising
{
    public class InterstitialAd : MonoBehaviour
    {
        [SerializeField] private Menu _menu;

        private Button _lockableButton;

        public event Action AdvertisingClosed;

        public void Initialize(Button lockableButton)
        {
            _lockableButton = lockableButton;
        }

        public void Show()
        {
            Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallback);
        }

        private void OnOpenCallback()
        {
            _menu.StopTime();
            _menu.StopMusic();

            _lockableButton.interactable = false;
        }

        private void OnCloseCallback(bool isWorking)
        {
            _menu.ContinueTime();
            _menu.ContinueMusic();

            AdvertisingClosed?.Invoke();
        }
    }
}