using System.Collections;
using Agava.YandexGames;
using BS.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BS.Settings
{
    internal sealed class SDKInitializer : MonoBehaviour
    {
        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(LoudCloudSave);
        }

        private void LoudCloudSave()
        {
            Agava.YandexGames.Utility.PlayerPrefs.Load(OnLoadCloudSuccessCallback);
        }

        private void OnLoadCloudSuccessCallback()
        {
            SceneManager.LoadScene((int)SceneNames.Menu);
        }
    }
}