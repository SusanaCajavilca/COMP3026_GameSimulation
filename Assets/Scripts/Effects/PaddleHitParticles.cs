using UnityEngine;

public class PaddleHitParticles : MonoBehaviour
{

    public GameObject hitEffectPrefab; // Drag the PaddleHitEffect prefab here

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if the colliding object is the ball
        if (collision.gameObject.CompareTag("Ball") && hitEffectPrefab != null)
        {
            // Use the first contact point of the collision
            Vector3 spawnPos = collision.contacts[0].point;

            // Spawn the particle effect at the collision point
            Instantiate(hitEffectPrefab, spawnPos, Quaternion.identity);
        }
    }

}
