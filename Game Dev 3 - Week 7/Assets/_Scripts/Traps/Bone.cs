using UnityEngine;

namespace GameDevWithMarco.Trap
{
    public class Bone : MonoBehaviour
    {
        // Variables for movement between start and end points
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;
        [SerializeField] private float moveSpeed = 2f;

        private bool movingToEnd = true; // Direction of movement

        private void Update()
        {
            // Move the bone towards the target position
            Transform target = movingToEnd ? endPoint : startPoint;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Check if the bone has reached the target position
            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                movingToEnd = !movingToEnd; // Reverse direction

                // Rotate the sprite when switching direction
                Vector3 newScale = transform.localScale;
                newScale.x *= -1; // Flip the sprite horizontally
                transform.localScale = newScale;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collision is with the player's axe
            if (collision.gameObject.CompareTag("Axe"))
            {
                gameObject.SetActive(false);
                startPoint.gameObject.SetActive(false);
                endPoint.gameObject.SetActive(false);
            }
        }
    }
}
