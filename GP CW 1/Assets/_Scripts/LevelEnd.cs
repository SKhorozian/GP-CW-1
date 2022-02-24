using UnityEngine;
using UnityEngine.SceneManagement;

namespace SKhorozian.GPCW.Level
{
    public class LevelEnd : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player")) SceneManager.LoadScene("MainMenu");
        }
    }
}