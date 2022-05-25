using DG.Tweening;
using UnityEngine;

namespace MT.Core
{
    public class TowerAnimator
    {
        private readonly Transform _body;
        private readonly float _shakeDuration = 0.1f;
        private readonly float _shakeOffset = 0.1f;
        private readonly float _bounceDuration = 0.1f;
        private readonly float _defaultScale = 1f;
        private readonly float _bounceScale = 1.5f;


        public TowerAnimator(Transform body)
        {
            _body = body;
        }
        
        public void Shake()
        {
            var strength = new Vector3(_shakeOffset, _body.position.y, _shakeOffset);
            _body.DOShakePosition(_shakeDuration, strength);
        }

        public void Bounce()
        {
            _body.DOScale(_bounceScale, _bounceDuration).OnComplete(() =>
            {
                _body.DOScale(_defaultScale, _bounceDuration).SetEase(Ease.OutBounce);
            });
        }
    }
}