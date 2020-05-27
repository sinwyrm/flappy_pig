using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPig : MonoBehaviour
{
    public float upForce = 200f;  // flapping force variable to be configured within Unity

    private bool isKO = false; // is Flappy Pig Knocked-Out? (initialized to FALSE when game starts)
    private Rigidbody2D rb2D;  // variable to store Rigidbody2D component data
    private Animator anim;  // variable to store Animator component data

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  // collects and stores Rigidbody2D data for FlappyPig at start of game
        anim = GetComponent<Animator>();  // collects and stores Animator data for FlappyPig
    }

    void Update()
    {
        if (isKO == false)  // if the player has not been KO's proceed here
        {
            if (Input.GetMouseButtonDown (0))  // if the left mouse button is clicked
            {
                rb2D.velocity = Vector2.zero;  // resets rising or falling velocity to zero with each mouse click
                rb2D.AddForce(new Vector2(0, upForce));  // amount of rising force to add with each wing flap
                anim.SetTrigger("Flap");  // trigger the Flap animation upon applying upForce
            }
        }

    }

    void OnCollisionEnter2D ()  // any time a collision happens this function will be called
    {
        isKO = true;  // a collision means Flappy Pig is KO'd and flapping will be disabled
        anim.SetTrigger("KO");  // change FlappyPig to KO animation upon KO state
    }
}
