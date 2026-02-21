using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UIModule
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text healthText;

        public void SetHealthText(string current, string max) => healthText.text = $"{current} / {max}";

        public void SetHealthBar(float value) => healthBar.fillAmount = value;
    }
}