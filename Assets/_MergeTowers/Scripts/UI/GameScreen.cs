using DG.Tweening;
using UnityEngine;

namespace MT.UI
{
    public class GameScreen : ScreenBase
    {
        [SerializeField] private RectTransform _spawnButton;
        [SerializeField] private RectTransform _score;
        
        private float _scoreScreenPosX;
        private float _scoreOutScreenPosX;

        public override void Init()
        {
            SetScreenPositions();
            _spawnButton.DOScale(0, 0);
            _score.DOAnchorPosX(_scoreOutScreenPosX, 0);
        }

        private void SetScreenPositions()
        {
            _scoreOutScreenPosX = _score.anchoredPosition.x + _score.sizeDelta.x;
            _scoreScreenPosX = _scoreOutScreenPosX - _score.sizeDelta.x;
        }

        public override void Hide()
        {
            _spawnButton.DOScale(0, 0);
            _score.DOAnchorPosX(_scoreOutScreenPosX, _animDuration).SetEase(Ease.Linear);
        }

        public override void Show()
        {
            _spawnButton.DOScale(_defaultScale, _animDuration).SetEase(_easeType);
            _score.DOAnchorPosX(_scoreScreenPosX, _animDuration).SetEase(_easeType);
        }
    }
}
