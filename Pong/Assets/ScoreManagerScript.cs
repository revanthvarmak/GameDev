using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{   
    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;
    public Text leftPlayerScoreText;
    public Text rightPlayerScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftPlayerScoreText.text = leftPlayerScore.ToString();
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {   

        leftPlayerScoreText.text = leftPlayerScore.ToString();
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }
}
