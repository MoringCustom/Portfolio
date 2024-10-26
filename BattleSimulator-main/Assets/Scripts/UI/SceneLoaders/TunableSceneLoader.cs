using UnityEngine;

namespace BS.UI.SceneLoaders
{
    public class TunableSceneLoader : SceneLoader
    {
        [Range(1, 7)]
        [Tooltip("1 - Menu, 2 - City, 3 - Forest, 4 - Volcanic, 5 - Tropics, 6 - Winter, 7 - Castle")]
        [SerializeField] private int _sceneNumber;

        protected override int GetSceneNumber()
        {
            return _sceneNumber;
        }
    }
}