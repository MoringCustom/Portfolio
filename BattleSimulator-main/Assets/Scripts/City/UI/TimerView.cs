using BS.City.Mines;
using TMPro;
using UnityEngine;

namespace BS.City.UI
{
    public class TimerView : MonoBehaviour
    {
        private readonly float _timeFactor = 60f;
        private readonly string _zeroTimer = "00:00";
        private readonly string _timeSample = "00";

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Timer _timer;

        private void Update()
        {
            int minutes = Mathf.FloorToInt(_timer.CurrentTime / _timeFactor);
            int seconds = Mathf.FloorToInt(_timer.CurrentTime % _timeFactor);

            if (_timer.CurrentTime > 0)
                _text.text = $"{StylizeString(minutes)}:{StylizeString(seconds)}";
            else
                _text.text = _zeroTimer;
        }

        private string StylizeString(int time)
        {
            return time.ToString(_timeSample);
        }
    }
}