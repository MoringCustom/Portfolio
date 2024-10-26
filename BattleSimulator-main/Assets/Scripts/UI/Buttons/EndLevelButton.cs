using BS.Advertising;
using BS.UI.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;

namespace BS.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(InterstitialAd))]
    internal class EndLevelButton : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;

        private Button _button;
        private InterstitialAd _interstitialAd;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _interstitialAd = GetComponent<InterstitialAd>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(FinishLevel);
            _interstitialAd.AdvertisingClosed += OnAdvertisingClosed;
        }

        private void Start()
        {
            _interstitialAd.Initialize(_button);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(FinishLevel);
            _interstitialAd.AdvertisingClosed -= OnAdvertisingClosed;
        }

        private void FinishLevel()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        _interstitialAd.Show();
#else
            _sceneLoader.Load();
#endif
        }

        private void OnAdvertisingClosed()
        {
            _sceneLoader.Load();
        }
    }
}