using BS.Level;
using BS.Settings;
using BS.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BS.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class UnitSelectButton : MonoBehaviour
    {
        [SerializeField] private string _buildingName;

        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private PlayerSpawner _playerSpawner;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(SetUnit);
        }

        private void Start()
        {
            _price.text = _unitPrefab.Price.ToString();
            _button.interactable = GameSaver.HasBuilding(_buildingName);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SetUnit);
        }

        private void SetUnit()
        {
            _playerSpawner.SelectUnit(_unitPrefab);
        }
    }
}