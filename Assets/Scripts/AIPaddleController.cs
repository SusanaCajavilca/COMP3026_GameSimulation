using UnityEngine;

public class AIPaddleController : MonoBehaviour
{
    public float moveSpeed = 6f;
    private float yLimit;
    public Transform ball;

    // The AI paddle automatically follows the
    // ball’s Y position using Vector3.MoveTowards, 
    //creating an effective computer opponent.
    // The left Paddle is for the user and the right Paddle is for AI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate vertical movement limit so the paddle stays fully on screen
        float halfHeight = transform.localScale.y / 2f;
        yLimit = 4.5f - halfHeight;
        // the code above is also in my other 2 paddles (left and right)

    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null) return;

        
        Vector3 targetPosition = new Vector3(
            transform.position.x,
            ball.position.y,
            transform.position.z
        );

        // Using Vector3.MoveTowards, tracking the ball’s Y position and using Time.deltaTime
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Clamp to screen
        float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector3(transform.position.x, clampedY, 0);



    }
}
