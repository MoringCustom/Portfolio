using UnityEngine;

namespace BS.UI
{
    public class LookController : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
        }

        private void Update()
        {
            _rectTransform.LookAt(Camera.main.transform);
        }
    }
}