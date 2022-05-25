using MT.Presenters;
using UnityEngine;
using Zenject;

namespace MT.Core
{
    public class TowersSpawner : MonoBehaviour
    {
        private Game _game;
        private ButtonPresenter _buttonPresenter;
        private Tower.Factory _towerFactory;

        [Inject]
        public void Constructor(Game game, ButtonPresenter buttonPresenter, Tower.Factory towerFactory)
        {
            _game = game;
            _buttonPresenter = buttonPresenter;
            _towerFactory = towerFactory;
        }

        public void SpawnNewTower(Transform spawnPos)
        {
            var newTower = _towerFactory.Create(_game, _buttonPresenter).transform;
            newTower.position = spawnPos.position;
            newTower.rotation = Quaternion.identity;
            newTower.transform.SetParent(spawnPos);
        }
    }
}
