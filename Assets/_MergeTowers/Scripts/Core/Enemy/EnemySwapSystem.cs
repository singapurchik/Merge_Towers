using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MT.Core
{
    public class EnemySwapSystem
    {
        private readonly List<Tower> _towers;
        private readonly float _upOffset = 0.5f;
        private readonly float _upDuration = 0.5f;
        private readonly float _moveDuration = 1f;
        
        private bool _isSwap;
        public bool IsSwap => _isSwap;
        public event Action SwapDone;

        public EnemySwapSystem(List<Tower> towers)
        {
            _towers = towers;
        }

        public void TrySwapTowerPosition(Transform newPlace)
        {
            _isSwap = true;
            var randomTower = _towers[Random.Range(0, _towers.Count)].transform;
            var grabPos = randomTower.position.y + _upOffset;
            
            randomTower.DOMoveY(grabPos, _upDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                randomTower.DOMove(newPlace.position, _moveDuration).SetEase(Ease.InOutCubic).OnComplete(()=>
                {
                    _isSwap = false;
                    SwapDone?.Invoke();
                });
            });
        }
    }
}