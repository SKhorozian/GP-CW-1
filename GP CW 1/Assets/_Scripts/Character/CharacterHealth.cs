using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SKhorozian.GPCW.Combat
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private int currentHealth = 5;

        public UnityEvent<int> OnDamageTaken;
        public void TakeDamage() {
            currentHealth--;

            currentHealth = Mathf.Clamp(currentHealth, 0, 5);

            if (currentHealth == 0) Die();

            OnDamageTaken?.Invoke(currentHealth);
        }

        private void Die() {
            SceneManager.LoadSceneAsync("LevelScene");
        }
    }
}