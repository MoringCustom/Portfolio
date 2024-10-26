namespace BS.UI.SceneLoaders
{
    public class SelectiveSceneLoader : SceneLoader
    {
        private int _sceneNumber = 3;

        public void SelectScene(int sceneNumber)
        {
            _sceneNumber = sceneNumber;
        }

        protected override int GetSceneNumber()
        {
            return _sceneNumber;
        }
    }
}