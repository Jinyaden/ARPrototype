using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARImageTrackingDemo.MainMenu
{    public class MainMenu : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }
        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
