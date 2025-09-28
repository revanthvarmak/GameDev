using UnityEngine;

public class SpawnRevanthScript : MonoBehaviour
{   
    public GameObject Rev;
    public float timer = 0;
    public float spawnRate = 2;

    public float heightOffset = 3.21f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // spawnRevanth();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnRate){
            spawnRevanth();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void spawnRevanth(){
        float halfGap = 3.21f; // half distance between top & bottom pipe centers

        float minY = Camera.main.transform.position.y - Camera.main.orthographicSize + halfGap;
        float maxY = Camera.main.transform.position.y + Camera.main.orthographicSize - halfGap;

        float spawnY = Random.Range(minY, maxY);
        float spawnX = transform.position.x + 10;

        Instantiate(Rev, new Vector3(spawnX, spawnY, 0), transform.rotation);
    }
}
