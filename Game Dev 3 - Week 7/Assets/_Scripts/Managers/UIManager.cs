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

        public void UpdateScoreText()
        {
            scoreText.text = $"<b>Score</b>:{GameManager.Instance.Score}";
        }
    }
}
