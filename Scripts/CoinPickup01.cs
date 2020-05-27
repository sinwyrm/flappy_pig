using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)  // activates when scoring trigger is hit
        {
            if (other.GetComponent<FlappyPig>() != null)  // verify the object is Flappy Pig
            {
                GameControl.instance.PigScored();  // run PigScored to add to current score
                Destroy(gameObject);  // destroy this collected coin
            }
    }
}
