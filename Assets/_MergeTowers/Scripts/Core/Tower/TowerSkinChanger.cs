using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MT.Core
{
    public class TowerSkinChanger : MonoBehaviour, ISkinChanger
    {
        private List<ISkin> _skins = new List<ISkin>();
        
        public void CreateSkinList()
        {
            _skins = transform.GetComponentsInChildren<ISkin>().ToList();
        }
        
        public void ChangeSkinOn(int level)
        {
            var skinIndex = level - 1;
            
            for (int i = 0; i < _skins.Count; i++)
            {
                if (i == skinIndex)
                    _skins[i].Show();
                else
                    _skins[i].Hide();
            }
        }
    }
}
