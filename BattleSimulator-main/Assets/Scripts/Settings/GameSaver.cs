using Agava.YandexGames.Utility;
using BS.StaticData;

namespace BS.Settings
{
    public static class GameSaver
    {
        private static readonly int _levelStep = 1;
        private static readonly float _maxVolume = 1f;
        private static readonly string _startBuilding = "SoldierHouse";

        public static int Money => PlayerPrefs.GetInt(StaticGameData.Money);
        public static int Score => PlayerPrefs.GetInt(StaticGameData.Score);
        public static int CurrentMap => PlayerPrefs.GetInt(StaticGameData.Map);
        public static int CurrentLevel => PlayerPrefs.GetInt(StaticGameData.Level);
        public static float Volume => PlayerPrefs.GetFloat(StaticGameData.Volume);
        public static bool IsGameConfigured => PlayerPrefs.HasKey(StaticGameData.Settings);

        public static bool HasBuilding(string name)
        {
            return PlayerPrefs.HasKey(name);
        }

        public static void SaveBuilding(string name)
        {
            PlayerPrefs.SetString(name, true.ToString());
            PlayerPrefs.Save();
        }

        public static void SetMoney(int value)
        {
            PlayerPrefs.SetInt(StaticGameData.Money, value);
            PlayerPrefs.Save();
        }

        public static void SetScore(int addedValue)
        {
            int score = PlayerPrefs.GetInt(StaticGameData.Score) + addedValue;

            PlayerPrefs.SetInt(StaticGameData.Score, score);
            PlayerPrefs.Save();
        }

        public static void SetVolume(float value)
        {
            PlayerPrefs.SetFloat(StaticGameData.Volume, value);
            PlayerPrefs.Save();
        }

        public static void SetMap(int mapNumber)
        {
            PlayerPrefs.SetInt(StaticGameData.Map, mapNumber);
            PlayerPrefs.Save();
        }

        public static void SetLevel(int levelNumber)
        {
            PlayerPrefs.SetInt(StaticGameData.Level, levelNumber);
            PlayerPrefs.Save();
        }

        public static void SetNextLevel(int levelsCount)
        {
            if (CurrentMap == (int)SceneNames.LevelChoiceScene)
                return;

            if (CurrentLevel == levelsCount)
                ChangeMap();
            else
                PlayerPrefs.SetInt(StaticGameData.Level, CurrentLevel + _levelStep);

            PlayerPrefs.Save();
        }

        public static void SetDefaultSettings()
        {
            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetInt(StaticGameData.Level, _levelStep);
            PlayerPrefs.SetInt(StaticGameData.Map, (int)SceneNames.Forest);
            PlayerPrefs.SetFloat(StaticGameData.Volume, _maxVolume);
            PlayerPrefs.SetString(_startBuilding, true.ToString());
            PlayerPrefs.SetString(StaticGameData.Settings, true.ToString());

            PlayerPrefs.Save();
        }

        private static void ChangeMap()
        {
            PlayerPrefs.SetInt(StaticGameData.Level, _levelStep);
            PlayerPrefs.SetInt(StaticGameData.Map, CurrentMap + _levelStep);
        }
    }
}