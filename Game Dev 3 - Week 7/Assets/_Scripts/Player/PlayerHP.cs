using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Managers;

namespace GameDevWithMarco.Player
{
    public class PlayerHP : MonoBehaviour
    {
        public int healthPoints = 10;
        public int damageValue;
        //public AudioSource playerHurt;
        //public AudioSource playerDed;
        public bool isPlayerDed = false;
        [SerializeField] GameManager gameManager;

        public void DealDamage()
        {

            // Deduct health and check if the player is dead, then plays a hurt sound
            healthPoints -= damageValue;
            //playerHurt.Play();

            if (healthPoints <= 0)
            {
                isPlayerDed = true;
                gameManager.GameOver();

                // Ensure the death sequence is delayed slightly to finish all actions
                StartCoroutine(HandlePlayerDeath());
            }
        }

        private IEnumerator HandlePlayerDeath()
        {
            // Short delay for good measure
            yield return new WaitForSeconds(0.1f);
            //playerDed.Play();
            Time.timeScale = 0; //Stops the timer to prevent the enemies from further spawning
        }

    }
}
