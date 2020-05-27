using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    private Rigidbody2D rb2d;  // variable to store Rigidbody2D component data

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  // get and store current Rigidbody2D component data
        rb2d.velocity = new Vector2(GameControl.instance.parallaxSpeed * FlappyPig.speedMultiplier, 0);  // move at parallaxSpeed velocity
    }

    void Update()
    {
        if (GameControl.instance.gameOver == true)  // if the game is over...
        {
            rb2d.velocity = Vector2.zero;  // stop scrolling
        }
    }
}
