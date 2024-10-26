using BS.Advertising;
using BS.Level;
using BS.UI.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;

namespace BS.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class AdvertisingEndLevelButton : MonoBehaviour
    {
        [SerializeField] private VideoAd _videoAd;
        [SerializeField] private BattleSceneLoader _sceneLoader;
        [SerializeField] private LevelSaver _levelSaver;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        _videoAd.Show(_button, FinishLevel);
#else
            FinishLevel();
#endif
        }

        private void FinishLevel()
        {
            _levelSaver.FinishLevel();
            _sceneLoader.Load();
        }
    }
}