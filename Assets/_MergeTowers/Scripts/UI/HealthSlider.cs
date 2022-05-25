using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MT.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private RectTransform _image;
        
        private Slider _slider;
        private readonly float _imageAnimDuration = 1f;
        private readonly float _sliderAnimDuration = 1f;
        private readonly float _shakePower = 3f;

        public void Initialize(int currentHealth)
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = currentHealth;
            _slider.value = _slider.maxValue;
        }

        public void UpdateSliderValue(int currentHealth)
        {
            ShakeImage();
            _slider.DOValue(currentHealth, _sliderAnimDuration);
        }

        private void ShakeImage()
        {
            _image.DOShakePosition(_imageAnimDuration,Vector3.up * _shakePower);
        }
    }
}