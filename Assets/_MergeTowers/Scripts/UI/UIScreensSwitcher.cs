using System.Collections;
using MT.Core;
using MT.Presenters;
using UnityEngine;

namespace MT.UI
{
    public class UIScreensSwitcher : MonoBehaviour
    {
        [SerializeField] private TutorialScreen _spawnTutorialScreen;
        [SerializeField] private TutorialScreen _mergeutorialScreen;
        [SerializeField] private ScreenBase _startScreen;
        [SerializeField] private ScreenBase _gameScreen;
        [SerializeField] private ScreenBase _winScreen;
        [SerializeField] private ScreenBase _loseScreen;
        [SerializeField] private ButtonPresenter _buttonPresenter;

        private void OnEnable()
        {
            _buttonPresenter.ShowTutorial += FirstLevelTutorial;
            _buttonPresenter.Start += GameScreen;

            if (PlayerPrefsController.CurrentLevel != 2) return;
            _buttonPresenter.Start += SecondLevelTutorial;
            EventManager.AddListener(CustomEventType.FirstMerge, HideSecondTutorial);
        }

        private void OnDisable()
        {
            _buttonPresenter.ShowTutorial -= FirstLevelTutorial;
            _buttonPresenter.Start -= GameScreen;

            if (PlayerPrefsController.CurrentLevel != 2) return;
            _buttonPresenter.Start -= SecondLevelTutorial;
            EventManager.RemoveListener(CustomEventType.FirstMerge, HideSecondTutorial);
        }

        private void Awake()
        {
            _spawnTutorialScreen.Init();
            _mergeutorialScreen.Init();
            _gameScreen.Init();
            _winScreen.Init();
            _loseScreen.Init();
        }

        private void FirstLevelTutorial()
        {
            _spawnTutorialScreen.ShowTutorial();
        }
        
        public void HideFirstTutorial()
        {
            _spawnTutorialScreen.Hide();
        }

        private void SecondLevelTutorial()
        {
            _mergeutorialScreen.ShowTutorial();
        }

        private void HideSecondTutorial(Hashtable param0)
        {
            _mergeutorialScreen.Hide();
        }

        private void GameScreen()
        {
            _startScreen.Hide();
        }

        public void SpawnScreen()
        {
            _gameScreen.Show();
        }

        public void WinScreen()
        {
            _gameScreen.Hide();
            _winScreen.Show();
        }

        public void LoseScreen()
        {
            _gameScreen.Hide();
            _loseScreen.Show();
        }
    }
}
