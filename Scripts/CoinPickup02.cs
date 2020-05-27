using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private float coinX;

    void Update()
    {
        coinX = transform.position.x;
        if (coinX <= -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)  // activates when scoring trigger is hit
    {
        if (other.GetComponent<FlappyPig>() != null)  // verify the object is Flappy Pig
        {
            GameControl.instance.PigScoredCoin();  // run PigScoredCoin to add to current score
            Destroy(gameObject);  // destroy this collected coin
        }
    }
}
