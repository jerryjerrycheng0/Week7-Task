using GameDevWithMarco.Data;
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
        [SerializeField] GlobalData globalData;

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
    }
}
