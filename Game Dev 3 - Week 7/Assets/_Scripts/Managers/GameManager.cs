using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Singleton;
using GameDevWithMarco.Data;

namespace GameDevWithMarco.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] GlobalData globalData;

        private void Start()
        {

            if(globalData != null)
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
            Debug.Log("GAME WON");
        }
        public void GameOver()
        {
            Time.timeScale = 0.2f;
        }
    }
}
