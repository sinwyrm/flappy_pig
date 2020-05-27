using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BGMusicControl : MonoBehaviour
{
    public AudioSource bgMusic; // variable for AudioSource
    public static bool musicOn = true;  // toggle for when BG music needs to be turned on/off

    void Awake()
    {
        bgMusic = GetComponent<AudioSource>();  // get AudioSource component data from BackgroundMusic GameObject
    }

    void Update()
    {
        if (musicOn == false)
        {
            bgMusic.Stop();  // stop playing BG music
        }
    }
}
