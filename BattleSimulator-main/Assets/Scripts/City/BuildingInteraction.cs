using System;
using BS.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace BS.City
{
    [RequireComponent(typeof(SphereCollider))]
    public class BuildingInteraction : MonoBehaviour
    {
        private readonly Color _unitIconDefaultColor = new Color(255, 255, 255, 255);

        [SerializeField] private Transform _building;
        [SerializeField] private Transform _lockedBuilding;
        [SerializeField] private Transform[] _effects;
        [SerializeField] private Canvas _priceView;
        [SerializeField] private Image _unitIcon;
        [SerializeField] private int _price;

        private SphereCollider _triggerCollider;

        public int Price => _price;

        private void Awake()
        {
            _triggerCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            GetLoad();
        }

        public void Unlock()
        {
            _lockedBuilding.gameObject.SetActive(false);
            _building.gameObject.SetActive(true);
            _triggerCollider.enabled = false;
            _priceView.gameObject.SetActive(false);

            if (_unitIcon != null)
                _unitIcon.color = _unitIconDefaultColor;

            if (!GameSaver.HasBuilding(gameObject.name))
                GameSaver.SaveBuilding(gameObject.name);
        }

        private void GetLoad()
        {
            if (GameSaver.HasBuilding(gameObject.name))
            {
                for (int i = 0; i < _effects.Length; i++)
                    Destroy(_effects[i].gameObject);

                Unlock();
            }
        }
    }
}