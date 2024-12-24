using UnityEngine;
using GameDevWithMarco.ObserverPattern;
using GameDevWithMarco.RandomStuff;

namespace GameDevWithMarco.Data
{
    [CreateAssetMenu(fileName = "New Global Data", menuName = "Scriptable Objects/Data")]
    public class GlobalData : ScriptableObject
    {
        public int score = 0;
        public int scoreRequiredToWin;
        [SerializeField] GameEvent gameWon;

        public event System.Action OnScoreChanged;

        public int Score
        {
            get { return score; }
        }

        public void ResetScore()
        {
            score = 0;
            OnScoreChanged?.Invoke();
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
            OnScoreChanged?.Invoke();

            if (score >= scoreRequiredToWin)
            {
                gameWon.Raise();
            }
        }
    }
}
