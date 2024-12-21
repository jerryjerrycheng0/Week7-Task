using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] GameObject axe;
        [SerializeField] GameObject axePrefabToThrow;
        [SerializeField] Transform axeHoldingPosition;
        [SerializeField] float axeDistanceRange;
        bool amIIHoldingTheAxe = true;
        [SerializeField] float axeForce;

        // Update is called once per frame
        void Update()
        {
            ThrowCollectTheAxe();
        }

        private void ThrowCollectTheAxe()
        {
            if (Input.GetKeyDown(KeyCode.Space) && amIIHoldingTheAxe)
            {
                // Deactivate the axe
                axe.SetActive(false);

                // Update state
                amIIHoldingTheAxe = false;

                // Spawn a new axe
                var thrownAxe = Instantiate(axePrefabToThrow, axeHoldingPosition.position, transform.rotation);

                // Add rigidbody2D and force
                Rigidbody2D rb = thrownAxe.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.right * axeForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        public void RecoverAxe()
        {
            // Update state
            amIIHoldingTheAxe = true;

            // Reactivate the real axe
            axe.SetActive(true);
        }
    }
}
