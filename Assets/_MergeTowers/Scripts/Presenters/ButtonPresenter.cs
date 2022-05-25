using System;
using DG.Tweening;
using MT.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MT.Presenters
{
    public class ButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _spawnButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _resetButton;

        public event Action Start;
        public event Action Spawn;

        public event Action ShowTutorial;

        private float _buttonSmall = 0.85f;
        private float _originalScale = 1f;
        private float _animDuration = 0.1f;
        private float _timeBeforeAction = 0.2f;

        public void StartButton()
        {
            Start?.Invoke();
        }

        public void SpawnButton()
        {
            Spawn?.Invoke();
            ButtonImpact(_spawnButton.transform);
        }

        public void NextButton()
        {
            ButtonImpact(_nextButton.transform, CustomEventType.Next);
        }

        public void ResetButton()
        {
            ButtonImpact(_resetButton.transform, CustomEventType.Reset);
        }

        public void EnableSpawnButton()
        {
            if(!_spawnButton.interactable)
                _spawnButton.interactable = true;
            
            if(PlayerPrefsController.LevelForPlayer == 1)
                ShowTutorial?.Invoke();
        }

        public void DisableSpawnButton()
        {
            if(_spawnButton.interactable)
                _spawnButton.interactable = false;
        }
        
        private void ButtonImpact(Transform button)
        {
            button.DOScale(_buttonSmall, _animDuration).OnComplete(() =>
            {
                button.DOScale(_originalScale, _timeBeforeAction)
                    .SetEase(Ease.OutBounce);
            });
        }
        
        private void ButtonImpact(Transform button, CustomEventType eventType)
        {
            button.DOScale(_buttonSmall, _animDuration).OnComplete(() =>
            {
                button.DOScale(_originalScale, _timeBeforeAction)
                    .SetEase(Ease.OutBounce).OnComplete(() =>
                    {
                        EventManager.TriggerEvent(eventType, null);
                    });
            });
        }
    }

}