using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Interfaces;
using GameDevWithMarco.ObserverPattern;

namespace GameDevWithMarco
{
    public class TrapDamage : MonoBehaviour, IDamagable
    {
        [SerializeField] GameEvent collidedWithTrap;
        [SerializeField] AudioSource hurtSound;

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
                damageable.Damage(1); // Assuming a damage value of 1 from the trap
            }
        }

        // IDamagable implementation for traps (not needed but required by interface)
        public void Damage(int amount)
        {
            // This can be left empty unless traps need to take damage themselves
        }
    }
}
