using DG.Tweening;
using UnityEngine;

namespace MT.UI
{
    public abstract class ScreenBase : MonoBehaviour, IScreen
    {
        protected Ease _easeType = Ease.OutBounce;
        protected readonly float _animDuration = 0.35f;
        protected readonly float _defaultScale = 1f;
        public abstract void Init();
        public abstract void Hide();

        public abstract void Show();
    }
}
