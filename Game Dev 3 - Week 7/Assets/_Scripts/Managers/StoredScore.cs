using UnityEngine;
using GameDevWithMarco.Data;
using TMPro;
using GameDevWithMarco.Player;
using UnityEngine.SceneManagement;

namespace GameDevWithMarco.Managers
{
    public class StoredScore : MonoBehaviour
    {
        [SerializeField] GlobalData globalData;
        [SerializeField] GameObject scoreUI;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] PlayerHP playerHP;

        private static int accumulatedScore = 0;

        private void Start()
        {
            scoreText.gameObject.SetActive(false);
            scoreUI.gameObject.SetActive(false);

            if (playerHP == null)
            {
                playerHP = FindObjectOfType<PlayerHP>();
            }

            if (scoreText != null)
            {
                // Display the accumulated score (which is across scenes)
                scoreText.text = $"Accumulated Score: {accumulatedScore}";
            }

            // Update the UI with the current accumulated score

        }

        private void Update()
        {
            UpdateScoreTextOnUI();
            CheckWinOrLoseCondition();
            if(playerHP != null && playerHP.isPlayerDed)
            {
                globalData.score = 0;
            }
        }

        private void OnEnable()
        {
            if (globalData != null)
            {
                globalData.OnScoreChanged += HandleScoreChange;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            if (globalData != null)
            {
                globalData.OnScoreChanged -= HandleScoreChange;
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void HandleScoreChange()
        {
            UpdateScoreTextOnUI();
            CheckWinOrLoseCondition();
        }

        public void UpdateScoreTextOnUI()
        {
            if (scoreText != null)
            {
                // Display the accumulated score (which is across scenes)
                scoreText.text = $"Accumulated Score: {accumulatedScore + globalData.Score}";
            }
        }

        private void CheckWinOrLoseCondition()
        {
            // If the player's health reaches zero, or if the score for this scene reaches the required value, show the score UI
            if ((globalData != null && globalData.Score >= globalData.scoreRequiredToWin) || (playerHP != null && playerHP.isPlayerDed))
            {
                scoreText.gameObject.SetActive(true);
                scoreUI.gameObject.SetActive(true);
            }
        }

        private void SaveStoredScore()
        {
            // Add the score from the current scene to the accumulated score only when transitioning
            accumulatedScore += globalData.Score; // Accumulate the global score for this scene into the total
            globalData.ResetScore(); // Reset the score after adding it to the accumulated score
        }

        private void ResetStoredScore()
        {
            accumulatedScore = 0; // Reset the accumulated score when returning to the first scene
            globalData.ResetScore(); // Reset the global score
        }

        private bool IsFirstScene()
        {
            return SceneManager.GetActiveScene().buildIndex == 0; // Check if it's the first scene (0 index)
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (IsFirstScene())
            {
                // Show the accumulated score (which should be 4 if starting on the first scene)
                UpdateScoreTextOnUI();
                globalData.ResetScore(); // Reset the global score when loading the first scene
                ResetStoredScore();
            }
            else
            {
                // Save the score from the previous scene into the accumulated score when transitioning
                SaveStoredScore();
                UpdateScoreTextOnUI(); // Update the UI with the accumulated score
            }
        }
    }
}