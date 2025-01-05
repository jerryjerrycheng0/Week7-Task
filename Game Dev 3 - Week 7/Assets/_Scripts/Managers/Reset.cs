using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevWithMarco.Managers
{
    public class Reset : MonoBehaviour
    {
        public void Restarter()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;

        }
        public void RestartFromBeginning()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;

        }
        public void Continue()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
            
        }

    }
}
