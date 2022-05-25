using UnityEngine;

namespace MT.Core
{
    public class CharacterSpawnPlaceChecker
    {
        private readonly Transform _tower;
        private readonly LayerMask _towerLayer;
        private readonly float _rayDistance = 3f;

        public CharacterSpawnPlaceChecker(Transform tower, LayerMask towerLayer)
        {
            _tower = tower;
            _towerLayer = towerLayer;
        }
        public bool SpawnSpaceBlocked()
        {
            return Physics.Raycast(_tower.position, _tower.forward, _rayDistance, _towerLayer);
        }
    }
}