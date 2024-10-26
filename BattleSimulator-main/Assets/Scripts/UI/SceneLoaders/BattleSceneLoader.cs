using BS.Settings;

namespace BS.UI.SceneLoaders
{
    public class BattleSceneLoader : SceneLoader
    {
        protected override int GetSceneNumber()
        {
            return GameSaver.CurrentMap;
        }
    }
}