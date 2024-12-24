using UnityEngine;
using GameDevWithMarco.Data;
using TMPro;
using GameDevWithMarco.Singleton;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Managers
{
    public class StoredScore : MonoBehaviour
    {
        [SerializeField] GlobalData globalData;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] PlayerHP playerHP;

        private void OnEnable()
        {
            if (globalData != null)
            {
                globalData.OnScoreChanged += UpdateScoreTextOnUI;
            }
        }

        private void OnDisable()
        {
            if (globalData != null)
            {
                globalData.OnScoreChanged -= UpdateScoreTextOnUI;
            }
        }

        private void Start()
        {
            scoreText.gameObject.SetActive(false);
            UpdateScoreTextOnUI();
            playerHP = FindAnyObjectByType<PlayerHP>();
        }

        public void UpdateScoreTextOnUI()
        {
            if (scoreText != null)
            {
                scoreText.text = $"Accumulated Score: {globalData.Score}";
            }
        }

        public void WinOrLose()
        {
            if (globalData.Score >= globalData.scoreRequiredToWin || playerHP.isPlayerDed)
            {
                scoreText.gameObject.SetActive(true);
            }
        }
    }
}
