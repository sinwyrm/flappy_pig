using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPig : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip postHit;
    public AudioClip groundHit;
    public AudioClip pointScored;
    public AudioClip pigFlap;
    // these all set up Flappy Pig's variables to assign sounds to


    public float upForce = 200f;  // flapping force variable to be configured within Unity

    private bool isKO = false; // is Flappy Pig Knocked-Out? (initialized to FALSE when game starts)
    private Rigidbody2D rb2D;  // variable to store Rigidbody2D component data
    private Animator anim;  // variable to store Animator component data
    private PolygonCollider2D fpCollide;

    private bool hasCollided = false;  // variable to determine if FP has already entered a collision state

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  // collects and stores Rigidbody2D data for FlappyPig at start of game
        anim = GetComponent<Animator>();  // collects and stores Animator data for FlappyPig
        audioSource = GetComponent<AudioSource>();  // collects and stores AudioSource component data for FP
    }

    void Update()
    {
        if (GameControl.godModeSet == true)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            rb2D.isKinematic = true;
        }

        if (isKO == false)  // if the player has not been KO's proceed here
        {
            if (Input.GetMouseButtonDown (0))  // if the left mouse button is clicked
            {
                rb2D.velocity = Vector2.zero;  // resets rising or falling velocity to zero with each mouse click
                rb2D.AddForce(new Vector2(0, upForce));  // amount of rising force to add with each wing flap
                anim.SetTrigger("Flap");  // trigger the Flap animation upon applying upForce

                PlaySound(pigFlap);  // wing flap sound every time mouse is clicked
            }
        }
    }

    void OnCollisionEnter2D ()  // any time a collision happens this function will be called
    {
        if (hasCollided != true)  // determine if FP is already in a collision state so this only runs once
        {
             hasCollided = true;  // set collsion state to true so repeated hits can't happen while falling

                rb2D.velocity = Vector2.zero;  // zero out Flappy Pig's velocity for when he hits the ground
                isKO = true;  // a collision means Flappy Pig is KO'd and flapping will be disabled
                anim.SetTrigger("KO");  // change FlappyPig to KO animation upon KO state
                GameControl.instance.FlappyPigKO();  // calls an instance of the FlappyPigKO fuction from the GameControl script

                // TO DO: set up differentiation between post collide and ground collide

                PlaySound(postHit);  //  play post collision sound effect

        }
        else if (hasCollided == true)  // if FP is already in a collision state
        {
                return;  // exit out without doing anything further
        }

    }

    public void PlaySound(AudioClip clip)  // function setup to play sound clips
    {
        audioSource.PlayOneShot(clip);  // play sound clip
    }
}
