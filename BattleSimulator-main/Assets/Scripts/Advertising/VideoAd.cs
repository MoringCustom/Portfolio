using System;
using BS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Advertising
{
    public class VideoAd : MonoBehaviour
    {
        [SerializeField] private Menu _menu;

        private Button _lockableButton;

        public void Show(Button lockableButton, Action<int> moneyAction, int money)
        {
            _lockableButton = lockableButton;
            Agava.YandexGames.VideoAd.Show(OnOpenCallback, () => moneyAction?.Invoke(money), OnCloseCallback);
        }

        public void Show(Button lockableButton, Action action)
        {
            _lockableButton = lockableButton;
            Agava.YandexGames.VideoAd.Show(OnOpenCallback, () => action?.Invoke(), OnCloseCallback);
        }

        private void OnOpenCallback()
        {
            _menu.StopTime();
            _menu.StopMusic();

            _lockableButton.interactable = false;
        }

        private void OnCloseCallback()
        {
            _menu.ContinueTime();
            _menu.ContinueMusic();

            _lockableButton.interactable = true;
        }
    }
}