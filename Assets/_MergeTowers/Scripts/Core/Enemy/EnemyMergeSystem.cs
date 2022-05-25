using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MT.Core
{
    public class EnemyMergeSystem
    {
        private readonly float _upOffset = 0.5f;
        private readonly float _upDuration = 0.5f;
        private readonly float _moveDuration = 1f;
        private readonly List<Tower> _towers;
        
        private Tower _mergeableTower;
        private int _towerIndex;
        private bool _isMerge;
        public bool IsMerge => _isMerge;
        public event Action MergeDone;

        public EnemyMergeSystem(List<Tower> towers)
        {
            _towers = towers;
        }
        
        public void TryToMergeTowers()
        {
            if (HasMergeableTowers())
            {
                MergeProcess();
            }
            else
            {
                _towerIndex++;
                if (_towerIndex >= _towers.Count)
                    _isMerge = true;
            }
        }

        private bool HasMergeableTowers()
        {
            for (int i = _towerIndex + 1; i < _towers.Count; i++)
            {
                if (_towers[i].Level != _towers[_towerIndex].Level) continue;
                _mergeableTower = _towers[i];
                return true;
            }
            return false;
        }
        
        private void MergeProcess()
        {
            _isMerge = true;
                
            var selectedTower = _towers[_towerIndex].transform;
            var grabPos = selectedTower.position.y + _upOffset;
            var mergeTowerPos = _mergeableTower.transform.position;
            var targetPos = new Vector3(mergeTowerPos.x, grabPos, mergeTowerPos.z);
                
            selectedTower.DOMoveY(grabPos, _upDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                selectedTower.DOMove(targetPos, _moveDuration).SetEase(Ease.InOutCubic).OnComplete(Merger);
            });
        }
        
        private void Merger()
        {
            _towers[_towerIndex].Kill();
            _towers.Remove(_towers[_towerIndex]);
            _mergeableTower.LevelUp();
            _mergeableTower = null;
            _towerIndex = 0;
            MergeDone?.Invoke();
            _isMerge = false;
        }
    }
}
