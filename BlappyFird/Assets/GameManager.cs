using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    public GameObject gameOverScreen;
    public int score = 0;

    public Text scoreText;

    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public AudioClip[] jumpSounds;

    public bool gameOver = false;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null){
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        if(scoreText != null){
            scoreText.text = score.ToString();
        }
    }

    public void UpdateScore()
    {   
        score++;
        Debug.Log("Score: " + score);
        if(scoreText != null){
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        gameOver = true;

        if(gameOverScreen != null){
            gameOverScreen.SetActive(true);
        }
        
        audioSource.PlayOneShot(gameOverSound);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayFlySound(){
        Debug.Log("PlayFlySound");
        if(jumpSounds.Length > 0 && audioSource != null && jumpSounds != null && !gameOver){
            int randomIndex = Random.Range(0, jumpSounds.Length);
            Debug.Log("PlayFlySound: " + randomIndex);
            audioSource.PlayOneShot(jumpSounds[randomIndex]);
        }
        else{
            Debug.Log("PlayFlySound: No jump sounds found");
        }
    }
}
