using UnityEngine;

namespace MT.Core
{
    public class PlayerPrefsController : MonoBehaviour
    {
        private const string Current_level = "Current_level";
        private const string Level_for_player = "Level_for_player";
        
        public static int CurrentLevel
        {
            set => PlayerPrefs.SetInt(Current_level, value);
            get => PlayerPrefs.GetInt(Current_level, 1);
        }

        public static int LevelForPlayer
        {
            set => PlayerPrefs.SetInt(Level_for_player, value);
            get => PlayerPrefs.GetInt(Level_for_player, 1);
        }
    }
}
