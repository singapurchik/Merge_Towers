using UnityEngine;

namespace MT.Core
{
    public class TowerPlacer
    {
        private OnBoardPlace _currentPlace;
        private readonly Transform _tower;

        public TowerPlacer(Transform tower)
        {
            _tower = tower;
        }

        public void SetNewPlace(OnBoardPlace place)
        {
            if (place.IsEmpty)
            {
                RemoveCurrentPlace();
                SetCurrentPlace(place);
                _tower.SetParent(_currentPlace.transform);
            }
        }

        public void RemoveCurrentPlace()
        {
            if (_currentPlace != null)
                _currentPlace.IsEmpty = true;
        }
        
        private void SetCurrentPlace(OnBoardPlace place)
        {
            _currentPlace = place;
            _currentPlace.IsEmpty = false;
        }
    }
}