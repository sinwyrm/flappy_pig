using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitSFX : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip groundClip;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
            audiosource.PlayOneShot(groundClip);
    }
}
