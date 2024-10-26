using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BS.UI.SceneLoaders
{
    public abstract class SceneLoader : MonoBehaviour
    {
        private readonly float _percentFactor = 100f;

        [SerializeField] private GameObject _loadPanel;
        [SerializeField] private TMP_Text _percent;

        public void Load()
        {
            _loadPanel.SetActive(true);
            StartCoroutine(StartLoad(GetSceneNumber()));
        }

        protected abstract int GetSceneNumber();

        private IEnumerator StartLoad(int sceneNumber)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber);

            while (asyncLoad.isDone == false)
            {
                float percent = Mathf.Round(asyncLoad.progress * _percentFactor);
                _percent.text = $"{percent}%";
                yield return null;
            }
        }
    }
}