using GameDevWithMarco.Data;
using GameDevWithMarco.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameDevWithMarco.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text requiredScoreText;
        [SerializeField] TMP_Text playerLives;
        [SerializeField] GlobalData globalData;
        [SerializeField] PlayerHP playerHP;
        [SerializeField] AudioSource coinGet;

        public void Start()
        {
            scoreText.text = $"<b>Score</b>: {globalData.Score}";
            playerLives.text = $"<b>Lives</b>: {playerHP.healthPoints}";
            requiredScoreText.text = $"<i><b>Score Required To Win</b></i>: {globalData.scoreRequiredToWin}";
        }
        public void UpdateScoreText()
        {
            if (globalData != null)
            {
                scoreText.text = $"<b>Score</b>: {globalData.Score}";
                coinGet.Play();
            }
            else
            {
                Debug.LogWarning("No Global Data SO assigned to the UI Manager");
            }
        }

        public void UpdateLivesText()
        {
            if (playerHP != null)
            {
                playerLives.text = $"<b>Lives</b>: {playerHP.healthPoints}";
            }
            else
            {
                Debug.LogWarning("No PlayerHP assigned to the UI Manager");
            }
        }

    }
}

