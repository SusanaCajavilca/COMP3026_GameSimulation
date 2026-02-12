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
}
