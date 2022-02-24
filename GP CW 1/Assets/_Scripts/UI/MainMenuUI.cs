using UnityEngine;
using UnityEngine.SceneManagement;

namespace SKhorozian.GPCW.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public void Play() {
            SceneManager.LoadScene("LevelScene");
        }

        public void Quit() {
            Application.Quit();
        }
    }
}