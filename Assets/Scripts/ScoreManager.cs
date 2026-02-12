using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int scoreLeft = 0;
    public int scoreRight = 0;

    public TextMeshProUGUI scoreText;
    public GameObject ball;

    public void GoalLeft()
    {
        scoreRight++;
        UpdateScoreText();
        ResetBall();
    }

    public void GoalRight()
    {
        scoreLeft++;
        UpdateScoreText();
        ResetBall();
    }

    void UpdateScoreText()
    {
        scoreText.text = scoreLeft + " : " + scoreRight;
    }

    void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        // Restart ball after a short delay
        ball.GetComponent<BallController>().Restart();
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
