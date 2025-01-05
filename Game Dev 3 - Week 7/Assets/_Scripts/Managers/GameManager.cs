using UnityEngine;
using GameDevWithMarco.Data;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GlobalData globalData;
        [SerializeField] PlayerHP playerHP;
        [SerializeField] AudioSource gameOverSound;
        [SerializeField] AudioSource gameWinSound;
        [SerializeField] GameObject[] uiElementsOver;  // UI elements for Game Over screen
        [SerializeField] GameObject[] uiElementsWin;   // UI elements for Game Win screen

        private void Start()
        {
            // Reset score and set the required score when the game starts
            if (globalData != null)
            {
                globalData.ResetScore();
                globalData.SetTheScoreRequiredToWin();
            }

            SetGOUIActive(false);
            SetGWUIActive(false);
        }

        public void GameWon()
        {
            Time.timeScale = 0f; // Stop the game time
            gameWinSound.Play();
            SetGWUIActive(true); // Activate Game Win UI
            Debug.Log("GAME WON");
        }

        public void GameOver()
        {
            if (playerHP.isPlayerDed)
            {
                SetGOUIActive(true);  // Activate Game Over UI
                gameOverSound.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f; // Stop the game time
            }
        }

        public void SetGOUIActive(bool isActive)
        {
            // Set each UI element active or inactive for the Game Over screen
            foreach (GameObject uiElement in uiElementsOver)
            {
                uiElement.SetActive(isActive);
            }
        }

        public void SetGWUIActive(bool isActive)
        {
            // Set each UI element active or inactive for the Game Win screen
            foreach (GameObject uiElement in uiElementsWin)
            {
                uiElement.SetActive(isActive);
            }
        }
    }
}
