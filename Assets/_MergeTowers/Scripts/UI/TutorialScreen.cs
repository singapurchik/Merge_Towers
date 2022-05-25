using UnityEngine;

namespace MT.UI
{
    public class TutorialScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _tutorial;
        
        public void Init()
        {
            Hide();
        }

        public void Hide()
        {
            _tutorial.SetActive(false);
        }

        public void ShowTutorial()
        {
            _tutorial.SetActive(true);
        }
    }
}
