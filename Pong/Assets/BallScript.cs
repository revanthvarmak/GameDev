using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{   
    private Rigidbody2D ballRigidbody;
    public float ballSpeed = 5f;
    public ScoreManagerScript scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {   

        Vector2 v = ballRigidbody.linearVelocity;

        if(collision.gameObject.CompareTag("Player"))
        {   
            // Keep the direction of the ball on collision, from unity but increase its speed
            v = v.normalized * ballSpeed;
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            v = new Vector2(v.x, -v.y).normalized * ballSpeed; 
        }

        ballRigidbody.linearVelocity = v;
    }

    void Update()
    {
        if(transform.position.x > 8.9f)
        {
            Debug.Log("Right Player Scored");
            scoreManager.leftPlayerScore++;
            ResetBall();
        }

        if(transform.position.x < -8.9f)
        {
            Debug.Log("Left Player Scored");
            scoreManager.rightPlayerScore++;
            ResetBall();
        }
    }

    

    void ResetBall()
    {   
        transform.position = new Vector3(0, 0, 0);
        ballRigidbody.linearVelocity = new Vector2(0, 0);
        Invoke("LaunchBall", 2f);
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-0.3f, 0.3f);
        ballRigidbody.linearVelocity = new Vector2(x, y);
        Vector2 dir = ballRigidbody.linearVelocity.normalized;
        ballRigidbody.linearVelocity = dir * ballSpeed;
    }

}
