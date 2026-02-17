using System.Buffers.Text;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();


    }

    void LaunchBall() 
    {
        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);

        rb.linearVelocity = new Vector2(x, y).normalized * speed;

    }

    public void Restart()
    {
        rb.linearVelocity = Vector2.zero;
        LaunchBall();
    }


    // Expansion 1: The curve ball
    // in short: The further from the paddle�s center the ball hits, the more vertical force it gains.
    /*
        Curve Ball makes the game more realistic and skill-based.
        Instead of the ball always bouncing the same way, its direction now depends on where it hits the paddle.
        If the ball hits near the center, it goes mostly straight.
        If it hits near the top or bottom, it gains more vertical movement and curves up or down.

        The new code calculates the difference between the ball's position and the paddle�s center,
        then uses that value to modify the ball's velocity.
        This introduces vector math and makes the gameplay less predictable and more engaging.
     
     */


    public void AddCurve(float hitOffset)
    {
        // Clamp hit offset so it stays reasonable
        hitOffset = Mathf.Clamp(hitOffset, -1f, 1f);

        Vector2 velocity = rb.linearVelocity;

        // Add vertical influence instead of replacing everything
        velocity.y += hitOffset * 4f;

        rb.linearVelocity = velocity.normalized * speed;


    }

    // the AddCurve method does:
    // 1. Preserves the natural physics bounce
    // 2. Adds vertical force based on hit position
    // 3. Normalizes velocity so overall speed stays consistent


    // Update is called once per frame
    void Update()
    {
        
    }
}


/* Discarded code for AddCurve:
 * 
 * Rigidbody2D rb = GetComponent<Rigidbody2D>();

//Vector2 newVelocity = new Vector2(rb.linearVelocity.x, hitOffset).normalized * speed;
Vector2 newVelocity = new Vector2(rb.linearVelocity.x, hitOffset * 3f).normalized * speed;
rb.linearVelocity = newVelocity;
*/