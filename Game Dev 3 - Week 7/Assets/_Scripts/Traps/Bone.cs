using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Trap
{
    public class Bone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collision is with an enemy bullet
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Axe"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
