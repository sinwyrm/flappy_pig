using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private MusicManager musicMgr;

    void Start()
    {
        musicMgr = FindObjectOfType<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(newTrack != null)
            {
                musicMgr.ChangeBGM(newTrack);
            }
        }
    }
}
