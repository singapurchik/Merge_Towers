using System.Collections.Generic;
using UnityEngine;

namespace MT.Core
{
    public class EnemyInput : MonoBehaviour
    {
        [SerializeField] private Board _enemyBoard;
        [SerializeField] private float _timeBetweenMerge = 4f;
        [SerializeField] private float _timeBetweenSwap = 2f;
        
        private PlaceFinder _placeFinder;
        private GlobalTimer _mergeTimer;
        private GlobalTimer _swapTimer;
        private EnemyMergeSystem _mergeSystem;
        private EnemySwapSystem _swapSystem;
        
        private bool _isGamePlay;

        private void OnDisable()
        {
            if(_mergeSystem != null)
                _mergeSystem.MergeDone -= _mergeTimer.ResetTimer;
            
            if(_swapSystem != null)
                _swapSystem.SwapDone -= _swapTimer.ResetTimer;
        }

        public void Initialize(List<Tower> towers)
        {
            _placeFinder = new PlaceFinder(_enemyBoard.GetTowerPlaces());
            _mergeTimer = new GlobalTimer();
            _swapTimer = new GlobalTimer();
            _mergeSystem = new EnemyMergeSystem(towers);
            _swapSystem = new EnemySwapSystem(towers);
            
            _mergeSystem.MergeDone += _mergeTimer.ResetTimer;
            _swapSystem.SwapDone += _swapTimer.ResetTimer;
        }

        private void Update()
        {
            if (!_isGamePlay) return;
            if(InteractiveWithSwapSystem()) return;
            if(InteractiveWithMergeSystem()) return;
        }

        private bool InteractiveWithMergeSystem()
        {
            if(_mergeSystem.IsMerge) return true;
            
            _mergeTimer.IncreaseTimer();
            if (_mergeTimer.timer >= _timeBetweenMerge)
            {
                _mergeSystem.TryToMergeTowers();
                return true;
            }
            return false;
        }
        
        private bool InteractiveWithSwapSystem()
        {
            if(_swapSystem.IsSwap) return true;
            
            if (_placeFinder.HasEmptyPlace())
            {
                _swapTimer.IncreaseTimer();
                if (_swapTimer.timer >= _timeBetweenSwap)
                {
                    _swapSystem.TrySwapTowerPosition(_placeFinder.GetEmptyPlace());
                    return true;
                }
            }
            return false;
        }

        public void GameStarted()
        {
            _isGamePlay = true;
        }

        public void GameFinish()
        {
            _isGamePlay = false;
        }
    }
}