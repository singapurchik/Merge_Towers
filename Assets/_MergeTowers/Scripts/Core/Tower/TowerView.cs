using UnityEngine;

namespace MT.Core
{
    public class TowerView
    {
        private readonly Transform _body;
        private readonly float _upStep = 1f;

        public TowerView(Transform body)
        {
            _body = body;
        }
        
        public void UpBody()
        {
            var grabPos = _body.position;
            grabPos.y += _upStep;
            _body.position = grabPos;
        }

        public void DownBody()
        {
            var grabPos = _body.position;
            grabPos.y -= _upStep;
            _body.position = grabPos;
        }
    }
}