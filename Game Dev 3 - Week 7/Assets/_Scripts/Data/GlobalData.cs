using GameDevWithMarco.ObserverPattern;
using GameDevWithMarco.RandomStuff;
using UnityEngine;

namespace GameDevWithMarco.Data
{
    [CreateAssetMenu(fileName = "New Global Data", menuName = "Scriptable Objects/Data")]
    public class GlobalData : ScriptableObject
    {
        public int score = 0;
        public int scoreRequiredToWin;
        [SerializeField] GameEvent gameWon;

        private void OnEnable()
        {
            // Reset the score when the script is reloaded or enabled
            ResetScore();
        }

        public int Score
        {
            get { return score; }
        }

        public void ResetScore()
        {
            // Reset score when the scene reloads or on enable
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
