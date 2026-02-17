using UnityEngine;

public class PaddleController_Right : MonoBehaviour
{
    public float moveSpeed = 8f;
    private float yLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate vertical movement limit so the paddle stays fully on screen
        float halfHeight = transform.localScale.y / 2f;
        yLimit = 4.5f - halfHeight;

    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Vertical2"); // here is the difference from left paddle
        float newY = transform.position.y + inputY * moveSpeed * Time.deltaTime;

        // Clamp movement to screen bounds
        newY = Mathf.Clamp(newY, -yLimit, yLimit);

        transform.position = new Vector3(transform.position.x, newY, 0);


    }

    // Expansion 1: The curve ball
    // in short: The further from the paddle’s center the ball hits, the more vertical force it gains.
    /*
        Curve Ball makes the game more realistic and skill-based.
        Instead of the ball always bouncing the same way, its direction now depends on where it hits the paddle.
        If the ball hits near the center, it goes mostly straight.
        If it hits near the top or bottom, it gains more vertical movement and curves up or down.

        The new code calculates the difference between the ball’s position and the paddle’s center,
        then uses that value to modify the ball’s velocity.
        This introduces vector math and makes the gameplay less predictable and more engaging.
     
     */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            float paddleCenterY = transform.position.y;
            float ballY = collision.transform.position.y;

            float hitOffset = ballY - paddleCenterY;

            collision.gameObject
                .GetComponent<BallController>()
                .AddCurve(hitOffset);
        }
    }

    // the OnCollisionEnter2D method does:
    // 1. Detects when the ball hits a paddle
    // 2. Measures where the ball hit relative to the paddle center
    // 3. Sends that offset to the ball to curve it

}
