using UnityEngine;

namespace SKhorozian.GPCW.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private GameObject[] hpUIs;

        public void UpdateUI(int newHP) {
            for (var i = 0; i < hpUIs.Length; i++) 
                hpUIs[i].SetActive(newHP > i);
        }
    }
}