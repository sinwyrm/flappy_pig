using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconSpawn : MonoBehaviour
{
    public void SpawnBacon()
    {
        float xA = PostPool.post1X;
        float xB = PostPool.post2X;
        float xDiff = xB - xA;
        float xHalfDiff = xDiff * 0.5f;
        float baconPositionX = new float();

        baconPositionX = xA + xHalfDiff;

        Vector2 baconSpawnPosition = new Vector2(baconPositionX, (Random.Range(-2.5f, 4.5f)));
        GameObject spawnNewBacon = (GameObject)Instantiate(Resources.Load("Bacon"), baconSpawnPosition, Quaternion.identity);
    }
}
