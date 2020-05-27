using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<FlappyPig>() != null)  // verify the object is Flappy Pig
        {
            FlappyPig.isPowerUp = true;
            Destroy(gameObject);
        }
    }
}
