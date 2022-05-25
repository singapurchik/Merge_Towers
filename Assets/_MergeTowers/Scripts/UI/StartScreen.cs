using DG.Tweening;
using UnityEngine;

namespace MT.UI
{
    public class StartScreen : ScreenBase
    {
        [SerializeField] private RectTransform _startButton;

        public override void Init()
        {
            Hide();
        }

        public override void Hide()
        {
            _startButton.DOScale(0, 0);
        }

        public override void Show()
        {
            _startButton.DOScale(_defaultScale, _animDuration).SetEase(_easeType);
        }
    }
}
