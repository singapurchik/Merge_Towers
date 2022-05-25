using System;
using System.Collections.Generic;
using MT.Presenters;
using MT.UI;
using UnityEngine;
using Zenject;

namespace MT.Core
{
    [RequireComponent(typeof(GameScore))]
    [RequireComponent(typeof(EnemyInput))]
    [RequireComponent(typeof(TowersSpawner))]
    public class Game : MonoBehaviour, IPlayable
    {
        [SerializeField] private UIScreensSwitcher _screensSwitcher;
        [SerializeField] private CamerasSwithcer _camerasSwithcer;
        [SerializeField] private Board _playerBoard;
        [SerializeField] private Castle _playerCastle;
        [SerializeField] private Castle _enemyCastle;
        [SerializeField] private List<Tower> _enemyTowers;

        private ButtonPresenter _buttonPresenter;
        private IPlayable _waitToStart;
        private TowersSpawner _towerSpawner;
        private PlaceFinder _placeFinder;
        private EnemyInput _enemyInput;
        private GameScore _score;
        public event Action GameFinished;

        [Inject]
        public void Constructor(ButtonPresenter buttonPresenter)
        {
            _buttonPresenter = buttonPresenter;
        }

        private void Awake()
        {
            _towerSpawner = GetComponent<TowersSpawner>();
            _waitToStart = GetComponent<IPlayable>();
            _placeFinder = new PlaceFinder(_playerBoard.GetTowerPlaces());
            _enemyInput = GetComponent<EnemyInput>();
            _enemyInput.Initialize(_enemyTowers);
            _score = GetComponent<GameScore>();
            _score.Initialize(_buttonPresenter);
        }

        private void OnEnable()
        {
            _playerCastle.Destroyed += Lose;
            _enemyCastle.Destroyed += Win;
            _buttonPresenter.Start += _waitToStart.GameStarted;
            _buttonPresenter.Start += GameStarted;
            _buttonPresenter.Start += _enemyInput.GameStarted;
            _buttonPresenter.Spawn += TrySpawnNewTower;
            
            if(PlayerPrefsController.CurrentLevel == 1)
                _buttonPresenter.Spawn += HideFirstLevelTutorial;
        }

        private void OnDisable()
        {
            _playerCastle.Destroyed -= Lose;
            _enemyCastle.Destroyed -= Win;
            _buttonPresenter.Start -= _waitToStart.GameStarted;
            _buttonPresenter.Start -= GameStarted;
            _buttonPresenter.Start -= _enemyInput.GameStarted;
            _buttonPresenter.Spawn -= TrySpawnNewTower;
            
            if(PlayerPrefsController.CurrentLevel == 1)
                _buttonPresenter.Spawn -= HideFirstLevelTutorial;
        }

        private void HideFirstLevelTutorial()
        {
            _screensSwitcher.HideFirstTutorial();
        }

        private void TrySpawnNewTower()
        {
            if (_placeFinder.HasEmptyPlace())
                SpawnTower();
        }

        private void SpawnTower()
        {
            _score.DecreaseScore();
            _towerSpawner.SpawnNewTower(_placeFinder.GetEmptyPlace());
        }

        public void GameStarted()
        {
            _camerasSwithcer.GameCamera();
            _screensSwitcher.SpawnScreen();
        }

        public void GameOver()
        {
            GameFinished?.Invoke();
            _enemyInput.GameFinish();
        }

        private void Win()
        {
            GameOver();
            DisableAllCharacters(HealthType.Player);
            _screensSwitcher.WinScreen();
        }

        private void Lose()
        {
            GameOver();
            DisableAllCharacters(HealthType.Enemy);
            _screensSwitcher.LoseScreen();
        }
        
        private void DisableAllCharacters(HealthType healthType)
        {
            var characters = FindObjectsOfType<Character>();
            foreach (var character in characters)
            {
                if (character.Health.Type == healthType)
                    character.Win();
                else
                    character.Die();
            }
        }
    }
}