using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    AudioSource audioSource;
    public static GameControl instance;
    public static bool godModeSet = false;
    public static float powerUpTime;
    public static float baconMove;
    public static float speedBoost;

    public bool godMode = false;
    public float powerSpeed = 1;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public float parallaxSpeed = -0.5f;
    public float powerUpDuration = 5.0f;
    public float baconMoveSpeed = 0.1f;

    public AudioClip pigSnort01;
    public AudioClip pigSnort02;
    public AudioClip pigSnort03;
    public AudioClip pigSnort04;
    public AudioClip pigSnort05;
    public AudioClip coinScoreSound;
    public GameObject gameOverText;
    public Text scoreText;

    private AudioClip[] pigSnort;
    private int score = 0;
    private MusicManager musicManager;


    void Awake()  // sets singleton state for GameControl
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
        musicManager = FindObjectOfType<MusicManager>();
        powerUpTime = powerUpDuration;
        speedBoost = powerSpeed;
        FlappyPig.speedMultiplier = powerSpeed;
        baconMove = baconMoveSpeed * FlappyPig.speedMultiplier;
        pigSnort = new AudioClip[] { pigSnort01, pigSnort02, pigSnort03, pigSnort04, pigSnort05 };
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
        int num = Random.Range(1, 5);
        audioSource.PlayOneShot(pigSnort[num]);
    }


    public void FlappyPigKO()
    {
        if (godModeSet != true)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            FlappyPig.isPowerUp = false;
            musicManager.BGM.Stop();
        }
    }
}

