using GameDevWithMarco.Managers;
using GameDevWithMarco.ObserverPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.RandomStuff;
using GameDevWithMarco.Data;

namespace GameDevWithMarco.Player
{


    public class CollectCoinsOnTriggerEnter : MonoBehaviour
    {
        [SerializeField] GameEvent coinCollected;
        [SerializeField] GlobalData globalData;
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Coin")
            {
                int coinValue = collision.GetComponent<Coin>().CoinValue;
                

                if (globalData != null)
                {
                    globalData.AddToScore(coinValue);
                    
                }
                else
                {
                    Debug.LogWarning("No Global Data SO assigned to the CCOTE script");
                }

                Destroy(collision.gameObject);

                coinCollected.Raise();
            }
        }
    }
}
