using MT.Core;
using TMPro;
using UnityEngine;


namespace MT.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LevelCounterView : MonoBehaviour
    {
        private TextMeshProUGUI _levelCounterText;
        private const string Level = "LEVEL";

        private void Awake()
        {
            _levelCounterText = GetComponent<TextMeshProUGUI>();
            UpdateText();
        }

        private void UpdateText()
        {
            var currentLevel = PlayerPrefsController.LevelForPlayer;
            _levelCounterText.text = Level + " " + currentLevel;
        }
    }
}
