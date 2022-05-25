using UnityEngine;

namespace MT.Core
{
    public class TowerSkin : MonoBehaviour, ISkin
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
