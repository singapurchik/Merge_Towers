using UnityEngine;

namespace MT.Core
{
    public class CharacterSpawner : MonoBehaviour, IPlayable
    {
        [SerializeField] private Character[] _characterPrefab;
        [SerializeField] private float _timeBetweenSpawn = 3f;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private bool _spawnFromAwake;

        private GlobalTimer _timer;

        private int _characterLevel;
        private bool _gameOver;
        public bool towerSelected;

        public void Initialize(int level)
        {
            _timer = new GlobalTimer();
            _characterLevel = level - 1;
            _timer.timer = _timeBetweenSpawn;
        }

        private void Update()
        {
            if(!_spawnFromAwake || _gameOver) return;
            ProcessSpawn();
        }

        private void ProcessSpawn()
        {
            if(towerSelected) return;
            _timer.IncreaseTimer();
            if (_timer.timer >= _timeBetweenSpawn)
            {
                Spawn();
                _timer.ResetTimer();
            }
        }

        private void Spawn()
        {
            Instantiate(_characterPrefab[_characterLevel], _spawnPosition.position, _spawnPosition.rotation, transform.root);
        }

        public void UpCharacterLevel()
        {
            _characterLevel++;
        }
        
        public void GameStarted()
        {
            _spawnFromAwake = true;
        }

        public void GameOver()
        {
            _gameOver = true;
        }
    }
}
