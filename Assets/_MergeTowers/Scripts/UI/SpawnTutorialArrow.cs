using DG.Tweening;
using UnityEngine;

namespace MT.UI
{
    public class SpawnTutorialArrow : MonoBehaviour
    {
        private float _downPos = -630f;
        private float _animDuration = 0.5f;
        private void OnEnable()
        {
            Animatade();
        }

        private void OnDisable()
        {
            transform.DOKill();
        }

        private void Animatade()
        {
            transform.DOLocalMoveY(_downPos, _animDuration)
                .SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
