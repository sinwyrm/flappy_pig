using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    AudioSource audioSource;  // define variable for AudioSource component
    public bool godMode = false;
    public AudioClip gameOverSound;  // assigned for game oversound effect
    public AudioClip pigSnort01;  // assigned Pig Snorts
    public AudioClip pigSnort02;
    public AudioClip pigSnort03;
    public AudioClip pigSnort04;
    public AudioClip pigSnort05;
    public AudioClip coinScoreSound;  // assigned sound for coin scoring
    public GameObject gameOverText;  // a reference to the game over text for when FP is KO'd
    public Text scoreText;  // a reference to the UI component that shows the current score on-screen

    public static GameControl instance;  // a reference to GameControl to be able to access it statically

    public bool gameOver = false;  // a flag to determine if a Game Over state exists
    public static bool godModeSet = false;  // developer cheat for testing
    public float scrollSpeed = -1.5f;  // the default scroll speed of background objects
    public float parallaxSpeed = -0.5f;  // the default scroll speed of the sky for parallax effect

    private int score = 0;  // declared score-tracking variable

    void Awake()  // sets singleton state for GameControl
    {
        if (instance == null)  // if a current GameControl doesn't already exist...
        {
            instance = this;  // make this the currently existing GameControl
        }
        else if (instance != this)  // else if another GameControl already does exist...
        {
            Destroy(gameObject);  // destroy this GameControl because it is a duplicate
        }
        audioSource = GetComponent<AudioSource>();  // get and store AudioSource component data
        //
        // TO DO: if in God mode, disable FP collisions
        //              -maybe create new function to handle this and disable physics
        //
    }

    void Update()  // runs every frame
    {
        if (godMode == true)
        {
            godModeSet = true;
        }

        if (gameOver == true && Input.GetMouseButtonDown(0))  // if the game is over and the mouse button is clicked...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // then reload the scene to restart game
            BGMusicControl.musicOn = true;  // toggle BG music back on
        }
    }

    public void PigScoredCoin()
    {
        if (gameOver)  // makes it impossible to score with a KO'd FP
        {
            return;  // exit without registering a score increase
        }
        score++;  // add +1 to the current score
        scoreText.text = "Score: " + score.ToString();  // modify the current score text
        //
        // TO DO: differentiate between coin and post scores - play different sounds
        //
        audioSource.PlayOneShot(coinScoreSound);  // play score sound effect

    }

    public void PigScoredPost()
    {
        if (gameOver)  // makes it impossible to score with a KO'd FP
        {
            return;  // exit without registering a score increase
        }
        score++;  // add +1 to the current score
        scoreText.text = "Score: " + score.ToString();  // modify the current score text

        int num = Random.Range(1, 6);  // get random number for sound effect

        switch (num)
        {
            case 1:
                audioSource.PlayOneShot(pigSnort01);  // play score sound effect
                break;
            case 2:
                audioSource.PlayOneShot(pigSnort02);  // play score sound effect
                break;
            case 3:
                audioSource.PlayOneShot(pigSnort03);  // play score sound effect
                break;
            case 4:
                audioSource.PlayOneShot(pigSnort04);  // play score sound effect
                break;
            case 5:
                audioSource.PlayOneShot(pigSnort05);  // play score sound effect
                break;
            default:
                audioSource.PlayOneShot(pigSnort01);  // play score sound effect
                break;
        }
        

    }


    public void FlappyPigKO()
    {
        if (godModeSet == false)  // if godMode is enabled then prevents Game Over
        {
            gameOverText.SetActive(true);  // activates the Game Over text
            gameOver = true;  // declares the current game to be over
            BGMusicControl.musicOn = false;  // toggles BG music off in BGMusicControl script
            audioSource.PlayOneShot(gameOverSound);  // play game over sound effect
        }
    }
}
