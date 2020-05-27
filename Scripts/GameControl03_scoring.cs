using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;  // a reference to GameControl to be able to access it statically
    public GameObject gameOverText;  // a reference to the game over text for when FP is KO'd
    public Text scoreText;  // a reference to the UI component that shows the current score on-screen
    public bool gameOver = false;  // a flag to determine if a Game Over state exists
    public bool godMode = false;  // developer cheat for testing
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
    }

    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))  // if the game is over and the mouse button is clicked...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // then reload the scene to restart game
        }
    }

    public void PigScored()
    {
        if (gameOver)  // makes it impossible to score with a KO'd FP
        {
            return;  // exit without registering a score increase
        }
        score++;  // add +1 to the current score
        scoreText.text = "Score: " + score.ToString();  // modify the current score text
    }

    public void FlappyPigKO()
    {
        if (godMode == false)  // if godMode is enabled then prevents Game Over
        {
            gameOverText.SetActive(true);  // activates the Game Over text
            gameOver = true;  // declares the current game to be over
        }
    }
}