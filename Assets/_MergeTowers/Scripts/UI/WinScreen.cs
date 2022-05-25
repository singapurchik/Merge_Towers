using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MT.UI
{
    public class WinScreen : ScreenBase
    {
        [SerializeField] private Button _winButton;
        [SerializeField] private Image _winImage;
        [SerializeField] private TextMeshProUGUI _winButtonText;
        [SerializeField] private TextMeshProUGUI _winImageText;

        private Image _buttonImage;

        public override void Init()
        {
            _buttonImage = _winButton.GetComponent<Image>();
            Hide();
        }

        public override void Hide()
        {
            _buttonImage.rectTransform.DOScale(0, 0);
            _buttonImage.DOFade(0, 0);
            _winButtonText.DOFade(0, 0);
            _winImageText.DOFade(0, 0);
            _winImage.DOFade(0, 0);
        }

        public override void Show()
        {
            _buttonImage.rectTransform.DOScale(1, 0);
            _buttonImage.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _winImage.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _winImageText.DOFade(1, _animDuration).SetEase(Ease.InFlash);
            _winButtonText.DOFade(1, _animDuration).SetEase(Ease.InFlash);
        }
    }
}
