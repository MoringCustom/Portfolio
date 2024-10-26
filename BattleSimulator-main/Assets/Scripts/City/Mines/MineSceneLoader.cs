using BS.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BS.City.Mines
{
    public class MineSceneLoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene((int)SceneNames.Mines, LoadSceneMode.Additive);
        }
    }
}