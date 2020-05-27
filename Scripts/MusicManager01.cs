using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip normal;
    public AudioClip powerUp;

    private AudioClip currentTrack;
    void Start()
    {
        BGM.Play();
    }

    void Update()
    {
        if (FlappyPig.isPowerUp == true)
            currentTrack = powerUp;
        else
            currentTrack = normal;
    }

    public void ChangeBGM(AudioClip music)
    {
        if (BGM.name == music.name)
            return;

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
