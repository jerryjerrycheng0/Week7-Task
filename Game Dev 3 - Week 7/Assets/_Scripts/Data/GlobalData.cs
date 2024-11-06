using System.Collections;
using System.Collections.Generic;
using GameDevWithMarco.ObserverPattern;
using GameDevWithMarco.RandomStuff;
using UnityEngine;

namespace GameDevWithMarco.Data
{
    [CreateAssetMenu(fileName = "New Global Data", menuName = "Scriptable Objects/Data")]
    public class GlobalData : ScriptableObject
    {
        private int score = 0;
        private int scoreRequiredToWin;
        [SerializeField] GameEvent gameWon;

        public int Score
        {
            get
            {
                return score;
            }
        }

        public void ResetScore()
        {

            score = 0;

        }

        public void SetTheScoreRequiredToWin()
        {
            scoreRequiredToWin = 0;

            Coin[] storeAllCoins = FindObjectsOfType<Coin>();

            foreach (Coin coin in storeAllCoins)
            {
                scoreRequiredToWin += coin.CoinValue;
            }
        }

        public void AddToScore(int amountToAdd)
        {
            int sortedScore = Mathf.Abs(amountToAdd);

            score += sortedScore;

            if (score >= scoreRequiredToWin)
            {
                gameWon.Raise();
            }

        }
    }
}
