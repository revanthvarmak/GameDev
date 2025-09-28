using UnityEngine;
using UnityEngine.InputSystem;

public class RightPaddleScript : MonoBehaviour
{   
    private float paddleSpeed = 2.5f;
    private float topBoundaryLimit;
    private float bottomBoundaryLimit;

    private Rigidbody2D paddleRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        paddleRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Calculate boundary limits based on camera view
        Collider2D paddleCollider = GetComponent<Collider2D>();
        float halfPaddleHeight = paddleCollider.bounds.size.y / 2;
        topBoundaryLimit = Camera.main.orthographicSize - halfPaddleHeight;
        bottomBoundaryLimit = -Camera.main.orthographicSize + halfPaddleHeight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        float dir = 0f;
        if(Keyboard.current.upArrowKey.isPressed){
            dir = 1f;
        }
        if(Keyboard.current.downArrowKey.isPressed){
            dir = -1f;
        }

        Vector2 target = paddleRigidbody.position + new Vector2(0, dir * paddleSpeed * Time.deltaTime);
        target.y = Mathf.Clamp(target.y, bottomBoundaryLimit, topBoundaryLimit);
        paddleRigidbody.MovePosition(target);
    }
}
