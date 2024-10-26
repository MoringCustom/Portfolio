using UnityEngine;

namespace Assets.Scripts
{
    public class FocusSoundController : MonoBehaviour
    {
        void OnApplicationFocus(bool hasFocus)
        {
            Silence(!hasFocus);
        }

        void OnApplicationPause(bool isPaused)
        {
            Silence(isPaused);
        }

        private void Silence(bool silence)
        {
            AudioListener.pause = silence;
            AudioListener.volume = silence ? 0 : 1;
        }
    }
}