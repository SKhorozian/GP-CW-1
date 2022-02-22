using SKhorozian.GPCW.Character;
using UnityEngine;
using UnityEngine.UI;

namespace SKhorozian.GPCW.UI
{
    public class StaminaView : MonoBehaviour
    {
        [SerializeField] private MovementProperties properties;
        [SerializeField] private Image fillFront;
        [SerializeField] private Image fillSmooth;

        [Space(10)] 
        [SerializeField] private float lerpAmount;

        [Space(10)]
        [SerializeField] private Color canDash;
        [SerializeField] private Color cannotDash;
        
        public void UpdateView(float currentPercent) {
            fillFront.fillAmount = currentPercent;

            fillFront.color = currentPercent < (properties.DashCost / properties.MaxStamina) ? cannotDash : canDash;
        }

        private void Update() {
            fillFront.gameObject.SetActive(fillFront.fillAmount < 1);
            fillSmooth.gameObject.SetActive(fillFront.fillAmount < 1);

            fillSmooth.fillAmount = fillSmooth.fillAmount > fillFront.fillAmount 
                ? (Mathf.Lerp(fillSmooth.fillAmount, fillFront.fillAmount, lerpAmount * Time.deltaTime)) 
                : fillFront.fillAmount;
        }

    }
}