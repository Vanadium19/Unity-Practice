using TMPro;
using UnityEngine;

namespace UIModule
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text target;

        public void SetText(string value) => target.text = value;
    }
}