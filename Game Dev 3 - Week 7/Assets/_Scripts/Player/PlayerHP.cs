using System.Collections;
using UnityEngine;
using GameDevWithMarco.Managers;
using GameDevWithMarco.Interfaces;

namespace GameDevWithMarco.Player
{
    public class PlayerHP : MonoBehaviour, IDamagable
    {
        public int healthPoints = 10;
        public int damageValue = 1;
        public bool isPlayerDed = false;
        
        [SerializeField] GameManager gameManager;
        [SerializeField] UIManager uiManager;

        private void Start()
        {
            isPlayerDed = false;
        }

        public void Damage(int amount)
        {
            DealDamage(amount);
        }

        public void DealDamage(int damage)
        {
            healthPoints -= damage;

            // Notify the UI of the updated health
            uiManager.UpdateLivesText();

            // Check if the player is dead
            if (healthPoints <= 0 && !isPlayerDed)
            {
                isPlayerDed = true;
                gameManager.GameOver();

                // Ensure the death sequence is delayed slightly to finish all actions
                StartCoroutine(HandlePlayerDeath());
            }
        }

        private IEnumerator HandlePlayerDeath()
        {
            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 0; // Stops the timer to prevent the enemies from further spawning
        }
    }
}

