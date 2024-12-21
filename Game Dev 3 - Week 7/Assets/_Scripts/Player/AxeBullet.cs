using System.Collections;
using UnityEngine;
using GameDevWithMarco.Managers;
using GameDevWithMarco.ObserverPattern;

namespace GameDevWithMarco.Player
{
    public class AxeBullet : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D rb;
        [SerializeField] GameEvent axeCollected;
        [SerializeField] GameEvent axeHit;
        public bool haveIHitThetarget = false;
        ScreenBounds screenBounds;

        // Spinning sound AudioSource on the axe prefab
        [SerializeField] AudioSource spinSound;

        [SerializeField] AudioSource axeHitted;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            screenBounds = FindObjectOfType<ScreenBounds>();

            // Start spinning sound when the axe is spawned
            if (spinSound != null)
            {
                spinSound.Play();
            }

            StartCoroutine(GrabbableAfterABit());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            axeHitted.Play();

            // Stops the rotation animation
            animator.SetTrigger("HitTarget");

            // Stops the spinning sound
            if (spinSound != null && spinSound.isPlaying)
            {
                spinSound.Stop();
            }

            // To keep track of logic
            haveIHitThetarget = true;

            // Raises the event
            axeHit.Raise();

            // Stops movement by destroying the rigidbody
            Destroy(rb);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && haveIHitThetarget)
            {
                // Raises the event to let the player know
                axeCollected.Raise();

                // Destroys this object since it is no longer needed
                Destroy(gameObject);
            }
        }

        IEnumerator GrabbableAfterABit()
        {
            // Waits for a bit
            yield return new WaitForSeconds(1.25f);

            // Makes the axe grabbable
            haveIHitThetarget = true;
        }
    }
}
