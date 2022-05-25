using UnityEngine;

namespace MT.Core
{
    public class TowerInvader
    {
        private readonly Camera _mainCamera;
        private IGrabalable _grabbedTower;
        private int _towerMask = 1 << 6;

        public TowerInvader(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public void TryToGrabTower()
        {
            if(FoundTower())
                _grabbedTower.Grab();
        }
        
        private Ray MouseRay()
        {
            return _mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        }

        private bool FoundTower()
        {
            if (Physics.Raycast(MouseRay(), out var hit, Mathf.Infinity, _towerMask))
            {
                if(hit.transform.TryGetComponent(out IGrabalable tower))
                {
                    _grabbedTower = tower;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void ReleaseTower()
        {
            if(_grabbedTower == null) return;
            _grabbedTower.Release();
            _grabbedTower = null;
        }
    }
}
