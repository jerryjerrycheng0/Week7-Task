using GameDevWithMarco.Data;
using GameDevWithMarco.Player;
using GameDevWithMarco.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameDevWithMarco
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text playerLives;
        [SerializeField] GlobalData globalData;
        [SerializeField] PlayerHP playerHP;

        public void UpdateScoreText()
        {
            if (globalData != null)
            {
                scoreText.text = $"<b>Score</b>:{globalData.Score}";
            }
            else
            {
                Debug.Log("No Global Data SO assigned to the UI Manager");
            }
            
        }

        public void UpdateLivesText()
        {
            if (globalData != null)
            {
                playerLives.text = $"<b>Lives</b>:" + playerHP.healthPoints;
            }
            else
            {
                Debug.Log("No PlayerHP assigned to the UI Manager");
            }

        }
    }
}
