using UnityEngine;

namespace MT.Core
{
    public class PlayerInput : MonoBehaviour, IPlayable
    {
        [SerializeField] private Camera _mainCamera;

        private TowerInvader _towerInvader;

        private bool _isGameStarted;

        private void Awake()
        {
            _towerInvader = new TowerInvader(_mainCamera);
        }

        private void Update()
        {
            if(_isGameStarted) return;
            
            if (Input.GetMouseButtonDown(0))
                _towerInvader.TryToGrabTower();

            if (Input.GetMouseButtonUp(0))
                _towerInvader.ReleaseTower();
        }

        public void GameStarted()
        {
            _isGameStarted = true;
        }

        public void GameOver()
        {
            throw new System.NotImplementedException();
        }
    }
}
