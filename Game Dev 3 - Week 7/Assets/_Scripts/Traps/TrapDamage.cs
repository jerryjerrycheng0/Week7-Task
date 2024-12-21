using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Interfaces;
using GameDevWithMarco.ObserverPattern;

namespace GameDevWithMarco.Traps
{
    public class TrapDamage : MonoBehaviour, IDamagable
    {
        [SerializeField] GameEvent collidedWithTrap;
        [SerializeField] AudioSource hurtSound;
        public int damageAmount;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collided object implements IDamagable
            var damageable = collision.gameObject.GetComponent<IDamagable>();
            if (damageable != null)
            {
                // Raise the trap collision event
                collidedWithTrap.Raise();

                // Play hurt sound
                hurtSound.Play();

                // Apply damage via the IDamagable interface
                damageable.Damage(damageAmount);
            }
        }

        
        public void Damage(int amount)
        {
            amount = damageAmount;
        }
    }
}
