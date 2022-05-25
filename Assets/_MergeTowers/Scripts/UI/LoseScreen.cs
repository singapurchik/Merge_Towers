using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MT.UI
{
    public class LoseScreen : ScreenBase
    {
        [SerializeField] private Button _loseButton;
        [SerializeField] private Image _loseImage;
        [SerializeField] private TextMeshProUGUI _loseButtonText;
        [SerializeField] private TextMeshProUGUI _loseImageText;

        private Image _buttonImage;

        public override void Init()
        {
            _buttonImage = _loseButton.GetComponent<Image>();
            Hide();
        }

        public override void Hide()
        {
            _buttonImage.rectTransform.DOScale(0, 0);
            _loseImage.DOFade(0, 0);
            _loseImageText.DOFade(0, 0);
            _buttonImage.DOFade(0, 0);
            _loseButtonText.DOFade(0, 0);
        }

        public override void Show()
        {
            _buttonImage.rectTransform.DOScale(1, 0);
            _loseImage.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _buttonImage.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _loseImageText.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _loseButtonText.DOFade(1, _animDuration).SetEase(Ease.InFlash);
        }
    }
}