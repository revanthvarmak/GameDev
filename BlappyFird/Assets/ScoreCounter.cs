using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("ScoreCounter: onTriggerEnter2D");
        if(other.tag == "Player"){
            Debug.Log("ScoreCounter: UpdateScore");
            if(GameManager.instance != null){
                GameManager.instance.UpdateScore();
            }
            else{
                Debug.Log("ScoreCounter: GameManager is null");
            }
        }
    }
}
