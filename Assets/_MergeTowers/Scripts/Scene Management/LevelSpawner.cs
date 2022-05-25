using System.Collections;
using MT.Core;
using UnityEngine;

namespace MT.SceneManagement
{
    public class LevelSpawner : MonoBehaviour
    {
        [SerializeField] private int _lastLevelIndex = 3;

        private GameObject _currentLevel;
        private GameObject _level;

        private int _firstLevel = 3;

        private void OnEnable()
        {
            EventManager.AddListener(CustomEventType.Reset, ReloadLevel);
            EventManager.AddListener(CustomEventType.Next, NextLevel);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(CustomEventType.Reset, ReloadLevel);
            EventManager.RemoveListener(CustomEventType.Next, NextLevel);
        }

        private void Start()
        {
            InstantLevel();
        }

        private void InstantLevel()
        {
            _level = Resources.Load<GameObject>($"Levels/Level_{PlayerPrefsController.CurrentLevel}");
            _currentLevel = Instantiate(_level);
        }

        private void ReloadLevel(Hashtable param)
        {
            Destroy(_currentLevel);
            InstantLevel();
        }

        private void NextLevel(Hashtable param)
        {
            if (PlayerPrefsController.CurrentLevel >= _lastLevelIndex)
            {
                PlayerPrefsController.CurrentLevel = _firstLevel;
            }
            else
            {
                PlayerPrefsController.CurrentLevel++;
            }

            PlayerPrefsController.LevelForPlayer++;
            ReloadLevel(null);
        }
    }
}
