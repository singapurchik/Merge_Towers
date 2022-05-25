using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MT.Core
{
    [RequireComponent(typeof(Image))]
    public class CharacterSpawnerView : MonoBehaviour
    {
        private Image _dangerImage;
        
        private readonly float _animDuration = 1f;
        private readonly float _dangerFade = 1f;

        private bool _isDanger;

        private void Awake()
        {
            _dangerImage = GetComponent<Image>();
        }

        public void ShowDanger()
        {
            if(_isDanger) return;
            _isDanger = true;
            _dangerImage.DOFade(_dangerFade, _animDuration)
                .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
        }

        public void HideDanger()
        {
            transform.DOKill();
            _dangerImage.DOFade(0, 0);
            _isDanger = false;
        }
    }
}