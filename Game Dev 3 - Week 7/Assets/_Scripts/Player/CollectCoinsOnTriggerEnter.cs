using GameDevWithMarco.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.RandomStuff;

namespace GameDevWithMarco.Player
{
    public class CollectCoinsOnTriggerEnter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Coin")
            {
                int coinValue = collision.GetComponent<Coin>().CoinValue;

                GameManager.Instance.AddToScore(coinValue);

                Destroy(collision.gameObject);
            }
        }
    }
}
