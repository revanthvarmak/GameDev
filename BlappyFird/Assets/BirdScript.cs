using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{   
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Boundary Settings")]
    public float topBoundary = 5.0f;
    public float bottomBoundary = -5.0f;

    // Update is called once per frame
    void Update()
    {   

        if(birdIsAlive && (transform.position.y > topBoundary || transform.position.y < bottomBoundary)){
            birdIsAlive = false;
            if(GameManager.instance != null){
                GameManager.instance.GameOver();
            }
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive){
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 1) * 4;
            GameManager.instance.PlayFlySound();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {   
        birdIsAlive = false;
        if(GameManager.instance != null){
            GameManager.instance.GameOver();
        }
        else{
            Debug.Log("BirdScript: GameManager is null");
        }
    }
}
