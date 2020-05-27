using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public float coinSpawnTime = 10f;  // time between coin spawns

    private float coinPositionX;
    private float coinPositionY;
    private float timeSinceLastCoinSpawn;

    void Update()
    {
        timeSinceLastCoinSpawn += Time.deltaTime;

        coinPositionX = Random.Range(10, 15);
        coinPositionY = Random.Range(-5, 5);


        if (timeSinceLastCoinSpawn >= coinSpawnTime)
        {
            timeSinceLastCoinSpawn = 0f;
            Vector2 coinPosition = new Vector2(coinPositionX, coinPositionY);
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);  // spawn new coin into game
        }

    }
}
