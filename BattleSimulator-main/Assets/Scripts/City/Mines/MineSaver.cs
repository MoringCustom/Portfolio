using UnityEngine;

namespace BS.City.Mines
{
    public class MineSaver : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}