using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Level
{
    public class LevelEnder : MonoBehaviour
    {
        private readonly WaitForSeconds _delay = new WaitForSeconds(5f);

        [SerializeField] private Button _startButton;
        [SerializeField] private Transform _enemySpawner;
        [SerializeField] private Transform _playerSpawner;
        [SerializeField] private LevelSaver _levelSaver;

        [Header("Result Panels")]
        [SerializeField] private GameObject _drawPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _congratulationsPanel;
        [SerializeField] private GameObject _closablePanel;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartTryEndLevel);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartTryEndLevel);
        }

        private void StartTryEndLevel()
        {
            StartCoroutine(TryEndLevel());
        }

        private IEnumerator TryEndLevel()
        {
            while (_enemySpawner.childCount != 0 && _playerSpawner.childCount != 0)
                yield return _delay;

            if (_enemySpawner.childCount == 0 && _playerSpawner.childCount == 0)
                _drawPanel.SetActive(true);
            else if (_playerSpawner.childCount == 0)
                _gameOverPanel.SetActive(true);
            else
                FinishLevel();

            _closablePanel.SetActive(false);
        }

        private void FinishLevel()
        {
            _levelSaver.FinishLevel();
            _congratulationsPanel.SetActive(true);
        }
    }
}