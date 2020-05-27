using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    AudioSource audioSource;
    public static GameControl instance;

    public bool godMode = false;
    public static bool godModeSet = false;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public float parallaxSpeed = -0.5f;
    public float powerUpDuration = 5.0f;
    public static float powerUpTime;
    public float baconMoveSpeed = 0.1f;
    public static float baconMove;

    public AudioClip gameOverSound;
    public AudioClip pigSnort01;
    public AudioClip pigSnort02;
    public AudioClip pigSnort03;
    public AudioClip pigSnort04;
    public AudioClip pigSnort05;
    public AudioClip coinScoreSound;
    public GameObject gameOverText;
    public Text scoreText;

    private int score = 0;
    //private float timeSincePowerUp;


    void Awake()  // sets singleton state for GameControl
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
        powerUpTime = powerUpDuration;
        baconMove = baconMoveSpeed;
    }

    void Update()
    {
        if (godMode == true)
        {
            godModeSet = true;
        }

        if (gameOver == true && Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            BGMusicControl.musicOn = true;
        }

        if (gameOver == true && Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void PigScoredCoin()
    {
        if (gameOver)
            return;

        score++;
        scoreText.text = "Score: " + score.ToString();
        audioSource.PlayOneShot(coinScoreSound);
    }

    public void PigScoredPost()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
        // ***TO DO***
        //      - turn this section into an array
        int num = Random.Range(1, 6);
        switch (num)
        {
            case 1:
                audioSource.PlayOneShot(pigSnort01);
                break;
            case 2:
                audioSource.PlayOneShot(pigSnort02);
                break;
            case 3:
                audioSource.PlayOneShot(pigSnort03);
                break;
            case 4:
                audioSource.PlayOneShot(pigSnort04);
                break;
            case 5:
                audioSource.PlayOneShot(pigSnort05);
                break;
            default:
                audioSource.PlayOneShot(pigSnort01);
                break;
        }
    }

    public void FlappyPigKO()
    {
        if (godModeSet != true)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            BGMusicControl.musicOn = false;
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
