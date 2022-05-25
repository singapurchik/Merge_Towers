using DG.Tweening;
using UnityEngine;

namespace MT.UI
{
    public class MergeTutorialArrow : MonoBehaviour
    {
        private float _leftPos = -1.4f;
        private float _rightPos = -0.6f;
        private float _upPos = 0.4f;
        private float _animDuration = 0.5f;

        private Vector3 _originalPos;
        private Ease _easeType = Ease.InOutFlash;
        private void OnEnable()
        {
            SetOriginalPos();
            Animatade();
        }

        private void OnDisable()
        {
            transform.DOKill();
            ToOriginalPos();
        }

        private void SetOriginalPos()
        {
            _originalPos = transform.localPosition;
        }

        private void ToOriginalPos()
        {
            transform.localPosition = _originalPos;
        }

        private void Animatade()
        {
            ToOriginalPos();
            transform.DOLocalMoveX(_leftPos, _animDuration).SetEase(_easeType).OnComplete(() =>
            {
                transform.DOLocalMoveY(_upPos, _animDuration * 2).SetEase(_easeType).OnComplete(() =>
                {
                    transform.DOLocalMoveX(_rightPos, _animDuration).SetEase(_easeType).OnComplete(Animatade);
                });
            });
        }
    }
}