using BS.Level;
using TMPro;
using UnityEngine;

namespace BS.UI.View
{
    public class UnitCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private PlayerSpawner _playerSpawner;

        private void OnEnable()
        {
            _playerSpawner.UnitsCountChanged += ShowValue;
        }

        private void OnDisable()
        {
            _playerSpawner.UnitsCountChanged -= ShowValue;
        }

        private void ShowValue(int value)
        {
            _text.text = $"{value} / {_playerSpawner.MaxSpawnCount}";
        }
    }
}