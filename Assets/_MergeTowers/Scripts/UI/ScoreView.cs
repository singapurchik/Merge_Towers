using DG.Tweening;
using TMPro;
using UnityEngine;

namespace MT.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _spawnAmount;

        private readonly float _scoreScale = 1.5f;
        private readonly float _scoreOriginalScale = 1;
        private readonly float _animDuration = 0.2f;
        
        public void SetSpawnAmount(int spawnAmount)
        {
            _spawnAmount.text = spawnAmount.ToString();
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = score.ToString();
        }
        
        public void NoMoneyAnim()
        {
            _scoreText.DOColor(Color.red, _animDuration).SetEase(Ease.OutCubic);
            _scoreText.DOScale(_scoreScale, _animDuration).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                _scoreText.DOScale(_scoreOriginalScale, _animDuration).SetEase(Ease.OutElastic);
                _scoreText.DOColor(Color.black, _animDuration).SetEase(Ease.OutElastic);
            });
        }
    }
}
