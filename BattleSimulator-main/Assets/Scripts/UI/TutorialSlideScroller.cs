using UnityEngine;

namespace BS.UI
{
    public class TutorialSlideScroller : MonoBehaviour
    {
        [SerializeField] private GameObject[] _slides;
        [SerializeField] private GameObject _mainButtons;

        private int _currentSlide = 0;
        private int _minSlideNumber = 0;
        private int _maxSlideNumber;

        private void Awake()
        {
            _maxSlideNumber = _slides.Length;
        }

        private void OnEnable()
        {
            Scroll();
        }

        public void Scroll()
        {
            if (_currentSlide >= _slides.Length)
            {
                EndSlideShow();
                return;
            }

            for (int i = 0; i < _slides.Length; i++)
                _slides[i].SetActive(i == _currentSlide);
        }

        public void SetNextSlide()
        {
            _currentSlide++;
            _currentSlide = Mathf.Min(_currentSlide, _maxSlideNumber);
        }

        public void SetPreviousSlide()
        {
            _currentSlide--;
            _currentSlide = Mathf.Max(_currentSlide, _minSlideNumber);
        }

        private void EndSlideShow()
        {
            _currentSlide = 0;
            gameObject.SetActive(false);

            if (_mainButtons != null)
                _mainButtons.SetActive(true);
        }
    }
}