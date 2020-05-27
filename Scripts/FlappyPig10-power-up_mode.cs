using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPig : MonoBehaviour
{
    public static bool isPowerUp = false;
    public static float speedMultiplier = 1;

    public float upForce = 200f;

    public AudioSource audioSource;
    public AudioClip postHit;
    public AudioClip groundHit;
    public AudioClip pointScored;
    public AudioClip pigFlap;
    public AudioClip normalBG;
    public AudioClip gameOverSound;
    public AudioClip powerFlap;

    private Rigidbody2D rb2D;
    private Animator anim;
    private PolygonCollider2D fpCollide;
    private MusicManager musicManager;

    private bool isKO = false;
    private bool hasCollided = false;
    private float timeSincePowerUp = 0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    void Update()
    {
        /* =================================
         *            GOD MODE
         * =================================*/
        if (GameControl.godModeSet == true)
        {
            transform.position = new Vector2 (0, transform.position.y);
            isPowerUp = true;
        }

        if (isKO == false)
        {
            if (isPowerUp == false)
            {
                anim.SetTrigger("Idle");
                // reset speed multiplier to 1 here
                speedMultiplier = 1;

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
                // assign increased speed multiplier here
                speedMultiplier = GameControl.speedBoost;

                if (Input.GetMouseButtonDown(0))
                {
                    rb2D.velocity = Vector2.zero;
                    rb2D.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("PowerFlap");
                }

                if (GameControl.godModeSet == true)
                    timeSincePowerUp = 0;
                else
                    timeSincePowerUp += Time.deltaTime;

                if (timeSincePowerUp >= GameControl.powerUpTime)
                {
                    isPowerUp = false;
                    musicManager.ChangeBGM(normalBG);
                    timeSincePowerUp = 0;
                }
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        if (isPowerUp | GameControl.godModeSet == true)
            return;

        if (hasCollided != true)
        {
            hasCollided = true;
            rb2D.velocity = Vector2.zero;
            isKO = true;
            anim.SetTrigger("KO");
            GameControl.instance.FlappyPigKO();
            PlaySound(postHit);
            PlaySound(gameOverSound);

        }
        else if (hasCollided == true)
                return;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
