using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;  // create GameObject variable to reference coin prefab once attached
    public float coinSpawnTime = 10f;  // time between coin spawns

    private float coinPositionX;  // spawn coin at X position
    private float coinPositionY;  // spawn coin at Y position
    private float timeSinceLastCoinSpawn;  // counter since last coin was spawned

    void Update()
    {
        timeSinceLastCoinSpawn += Time.deltaTime;  // add to counter every frame

        coinPositionX = Random.Range(10, 15);  // range for random X position
        coinPositionY = Random.Range(-5, 5);  // range for random Y position
        Vector2 coinPosition = new Vector2(coinPositionX, coinPositionY);  // set new coin position


        if (timeSinceLastCoinSpawn >= coinSpawnTime)  // check if counter has exceeded coin spawn wait time
        {
            timeSinceLastCoinSpawn = 0f;  // reset counter

            Instantiate(coinPrefab, coinPosition, Quaternion.identity);  // spawn new coin into game
        }

    }
}
