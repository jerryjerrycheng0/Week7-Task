using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Singleton;
using GameDevWithMarco.Data;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] GlobalData globalData;
        [SerializeField] PlayerHP playerHP;
        [SerializeField] AudioSource gameOverSound;
        [SerializeField] AudioSource gameWinSound;
        [SerializeField] GameObject[] uiElementsOver;  // Array to hold the UI elements to activate
        [SerializeField] GameObject[] uiElementsWin;

        private void Start()
        {
            SetGOUIActive(false);
            SetGWUIActive(false);
            CheckGlobalData();
        }


        private void CheckGlobalData()
        {
            if (globalData != null)
            {
                globalData.ResetScore();
                globalData.SetTheScoreRequiredToWin();
            }
            else
            {
                Debug.LogWarning("Global Data SO not assigned to Game Manager");
            }
        }

        public void GameWon()
        {
            Time.timeScale = 0f;
            gameWinSound.Play();
            SetGWUIActive(true);
            Debug.Log("GAME WON");
        }
        public void GameOver()
        {
            if (playerHP.isPlayerDed == true)
            {
                SetGOUIActive(true);

                // Play the Game Over sound
                if (gameOverSound != null)
                {
                    gameOverSound.Play();
                }

                // Unlock the cursor and make it visible
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // Pause the game
                Time.timeScale = 0; // Stop the game time
            }
        }

        public void SetGOUIActive(bool isActiveA)
        {
            // Set each UI element active or inactive
            foreach (GameObject uiElement in uiElementsOver)
            {
                uiElement.SetActive(isActiveA);
            }
        }

        public void SetGWUIActive(bool isActiveB)
        {
            // Set each UI element active or inactive
            foreach (GameObject uiElementTwo in uiElementsWin)
            {
                uiElementTwo.SetActive(isActiveB);
            }
        }
    }
}
