using System.Collections;
using MT.Presenters;
using MT.UI;
using UnityEngine;

namespace MT.Core
{
    public class GameScore : MonoBehaviour
    {
        [SerializeField] private int _currentScore;
        [SerializeField] private int _spawnAmount;
        [SerializeField] private ScoreView _view;

        private ButtonPresenter _buttonPresenter;

        public void Initialize(ButtonPresenter buttonPresenter)
        {
            _buttonPresenter = buttonPresenter;
            _view.UpdateScore(_currentScore);
            _view.SetSpawnAmount(_spawnAmount);
        }

        private void OnEnable()
        {
            EventManager.AddListener(CustomEventType.AddScore, IncreaseScore);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(CustomEventType.AddScore, IncreaseScore);
        }

        private bool HasScoreToSpawn()
        {
            return _currentScore >= _spawnAmount;
        }
        
        private void IncreaseScore(Hashtable param0)
        {
            _currentScore++;
            
            if(HasScoreToSpawn())
                _buttonPresenter.EnableSpawnButton();
            
            _view.UpdateScore(_currentScore);
        }

        public void DecreaseScore()
        {
            _currentScore -= _spawnAmount;

            if (!HasScoreToSpawn())
                _buttonPresenter.DisableSpawnButton();

            _view.UpdateScore(_currentScore);
        }

        public void DontHaveScoreToSpawnAnim()
        {
            _view.NoMoneyAnim();
        }
    }
}
