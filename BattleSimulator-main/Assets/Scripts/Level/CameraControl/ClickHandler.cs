using BS.Environment;
using BS.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BS.Level.CameraControl
{
    public class ClickHandler : MonoBehaviour
    {
        private readonly int _touchIndex = 0;

        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private Button _startButton;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OffHandler);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                ProcessGroundTouch();
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OffHandler);
        }

        private void ProcessGroundTouch()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(_touchIndex).fingerId))
                return;

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out PlayerGround ground))
                    _playerSpawner.Spawn(hitInfo.point);
                else if (hitInfo.collider.TryGetComponent(out Unit unit) && !unit.IsEnemy)
                    _playerSpawner.RemoveOneUnit(unit);
            }
        }

        private void OffHandler()
        {
            enabled = false;
        }
    }
}