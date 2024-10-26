using BS.Level;
using UnityEngine;
using UnityEngine.UI;

namespace BS.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class UnitsCleanButton : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Clean);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Clean);
        }

        private void Clean()
        {
            _playerSpawner.Clean();
        }
    }
}