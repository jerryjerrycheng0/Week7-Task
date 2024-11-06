using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Singleton;

namespace GameDevWithMarco.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public int score;

        public int Score
        {
            get
            {
                return score;
            }
        }

        public void AddToScore(int numberToAdd)
        {
            score += numberToAdd;
            Debug.Log($"The current score is {score}");
        }

    }
}
