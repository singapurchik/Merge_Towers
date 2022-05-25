using System.Collections.Generic;
using UnityEngine;

namespace MT.Core
{
    public abstract class Board : MonoBehaviour
    {
        public List<Line> lines = new List<Line>();
        
        private readonly List<OnBoardPlace> _towerPlaces = new List<OnBoardPlace>();
        private int _currentLinesCount;
        
        public List<OnBoardPlace> GetTowerPlaces()
        {
            foreach (var towerPlace in transform.GetComponentsInChildren<OnBoardPlace>())
            {
                _towerPlaces.Add(towerPlace);
            }

            return _towerPlaces;
        }

        public void ChangeLinesAmount(int linesAmount)
        {
            if (_currentLinesCount == linesAmount) return;
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].gameObject.SetActive(i <= linesAmount - 1);
                _currentLinesCount = linesAmount;
            }
        }
    }
}
