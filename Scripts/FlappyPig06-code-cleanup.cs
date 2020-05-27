using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPig : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    private PolygonCollider2D fpCollide;

    public AudioSource audioSource;
    public AudioClip postHit;
    public AudioClip groundHit;
    public AudioClip pointScored;
    public AudioClip pigFlap;

    public float upForce = 200f;  // flapping force

    private bool isKO = false;
    private bool hasCollided = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameControl.godModeSet == true)  // this disables collision and physics for FP
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            rb2D.isKinematic = true;
        }

        if (isKO == false)
        {
            if (Input.GetMouseButtonDown (0))  // if the right mouse button is clicked
            {
                rb2D.velocity = Vector2.zero;  // resets rising or falling velocity to zero with each mouse click
                rb2D.AddForce(new Vector2(0, upForce));  // amount of rising force to add with each wing flap
                anim.SetTrigger("Flap");  // trigger the Flap animation upon applying upForce
                PlaySound(pigFlap);  // wing flap sound every time mouse is clicked
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        if (hasCollided != true)  // determine if FP is already in a collision state so this only runs once
        {
             hasCollided = true;  // set collsion state to true so repeated hits can't happen while falling
                rb2D.velocity = Vector2.zero;  // FP falls with no residual velocity
                isKO = true;
                anim.SetTrigger("KO");
                GameControl.instance.FlappyPigKO();
                // TO DO: set up differentiation between post collide and ground collide
                PlaySound(postHit);
        }
        else if (hasCollided == true)
                return;

    }

    public void PlaySound(AudioClip clip)  // function setup to play sound clips
    {
        audioSource.PlayOneShot(clip);
    }
}
