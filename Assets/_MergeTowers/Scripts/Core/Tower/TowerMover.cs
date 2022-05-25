using UnityEngine;

namespace MT.Core
{
    public class TowerMover
    {
        private Camera _mainCamera;
        private readonly Transform _tower;
        private Vector3 _mouseOffset;
        private Vector3 _originalPos;
        
        private float _mouseZPos;

        public TowerMover(Transform tower)
        {
            SetCamera();
            _tower = tower;
        }

        public void Move()
        {
            _tower.position = new Vector3(GetMouseAsWorldPoint().x, 0, GetMouseAsWorldPoint().z) + _mouseOffset;
        }
        
        public void SetMoveValues()
        {
            SetCamera();
            _mouseZPos = _mainCamera.WorldToScreenPoint(_tower.position).z;
            _mouseOffset = _tower.position - new Vector3(GetMouseAsWorldPoint().x, 0, GetMouseAsWorldPoint().z);
        }

        public void SetOriginalPos()
        {
            _originalPos = _tower.localPosition;
        }

        public void MoveToOriginalPos()
        {
            _tower.localPosition = _originalPos;
        }
        private Vector3 GetMouseAsWorldPoint()
        {
            SetCamera();
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _mouseZPos;
            return _mainCamera.ScreenToWorldPoint(mousePoint);
        }

        private void SetCamera()
        {
            if(_mainCamera == null)
                _mainCamera = Camera.main;
        }
    }
}
