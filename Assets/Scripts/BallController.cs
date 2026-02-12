using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
