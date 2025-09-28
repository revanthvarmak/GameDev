using UnityEngine;

public class MoveRevanthScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-1, 0, 0) * 3 * Time.deltaTime;
        if(transform.position.x < -12){
            Destroy(gameObject);
        }
    }
}
