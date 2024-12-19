using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Player;
using GameDevWithMarco.Interfaces;
using GameDevWithMarco.ObserverPattern;

namespace GameDevWithMarco
{
    public class TrapDamage : MonoBehaviour, IDamagable
    {
        [SerializeField] GameEvent collidedWithTrap;
        [SerializeField] PlayerHP playerHP;
        int damageInt;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Creates a local variable of type Rigidbody2D and initialises it
            Rigidbody2D rb = new Rigidbody2D();
            //Gets the rigid body of the collision object
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            //Raises the event
            collidedWithTrap.Raise();
            Damage();
        }

        public void Damage()
        {
            damageInt = playerHP.damageValue;
        }
    }
}
