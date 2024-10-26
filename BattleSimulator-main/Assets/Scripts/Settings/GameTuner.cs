using UnityEngine;

namespace BS.Settings
{
    public class GameTuner : MonoBehaviour
    {
        private void Awake()
        {
            if (GameSaver.IsGameConfigured == false)
                GameSaver.SetDefaultSettings();
        }

        private void Start()
        {
            AudioListener.volume = GameSaver.Volume;
        }
    }
}