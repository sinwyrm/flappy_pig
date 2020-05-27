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

    public float upForce = 200f;
    public static bool isPowerUp = false;

    private bool isKO = false;
    private bool hasCollided = false;
    float timeSincePowerUp = 0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameControl.godModeSet == true)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            rb2D.isKinematic = true;
            isPowerUp = true;
        }

        if (isKO == false)
        {
            if (isPowerUp == false)
            {
                anim.SetTrigger("Idle");
                if (Input.GetMouseButtonDown(0))
                {
                    rb2D.velocity = Vector2.zero;
                    rb2D.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("Flap");
                    PlaySound(pigFlap);
                }
            }

            if (isPowerUp == true)
            {
                anim.SetTrigger("PowerIdle");
                // TO DO:
                //GetComponent<PolygonCollider2D>().enabled = false;  // change this to disable post colliders
                if (Input.GetMouseButtonDown(0))
                {
                    rb2D.velocity = Vector2.zero;
                    rb2D.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("PowerFlap");
                    PlaySound(pigFlap);
                }
                timeSincePowerUp += Time.deltaTime;

                if (timeSincePowerUp >= GameControl.powerUpTime)
                {
                    isPowerUp = false;
                    timeSincePowerUp = 0;
                }
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        if (hasCollided != true)
        {
             hasCollided = true;
                rb2D.velocity = Vector2.zero;
                isKO = true;
                anim.SetTrigger("KO");
                GameControl.instance.FlappyPigKO();
                // TO DO: set up differentiation between post collide and ground collide
                PlaySound(postHit);
        }
        else if (hasCollided == true)
                return;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
