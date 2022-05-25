using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MT.Core
{
    public class GameBoardSize : MonoBehaviour
    {
        [Range(1, 4)] [SerializeField] private int _size = 1;

        private List<Board> _boards = new List<Board>();


#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                if(this == null) return;
                CreateBoardsList();
                LinesOnBoard();
            };
        }

        private void CreateBoardsList()
        {
            if (_boards.Count != 0) return;
            foreach (var board in transform.GetComponentsInChildren<Board>())
            {
                _boards.Add(board);
            }
        }

        private void LinesOnBoard()
        {
            foreach (var board in _boards)
                board.ChangeLinesAmount(_size);
        }
#endif
    }
}
