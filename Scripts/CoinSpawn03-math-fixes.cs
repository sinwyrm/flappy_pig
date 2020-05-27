using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public void SpawnCoin()
    {
        float coinPositionY = new float();
        float coinPositionX = new float();
        float top = 5.0f;
        float ground = -2.662f;
        float middlePlayArea = 1.169f;
        float xA = PostPool.post1X;
        float xB = PostPool.post2X;
        float yA = PostPool.post1Y;
        float yB = PostPool.post2Y;
        float xDiff = xB - xA;
        float xHalfDiff = xDiff * 0.5f;
        //float xMid = xA + (xDiff * 0.5f);
        float yDiff;

        Debug.Log($"POST 1: {xA}, {yA} / POST 2: {xB}, {yB}");

        if (yA < yB)
        {
            yDiff = yB - yA;
            float yHalfDiff = yDiff / 2f;

            coinPositionX = xA + xHalfDiff;// + (0.5f * xHalfDiff);
            if (yB - yHalfDiff > middlePlayArea)
            coinPositionY = ground + yDiff;
            if (yB - yHalfDiff <= middlePlayArea)
                coinPositionY = top - yDiff;

            Debug.Log($"Coin : {coinPositionX}, {coinPositionY}");
        }
        else if (yA >= yB)
        {
            yDiff = yA - yB;
            float yHalfDiff = yDiff / 2f;

            coinPositionX = xA + xHalfDiff;// - (0.5f * xHalfDiff);
            if (yA - yHalfDiff > middlePlayArea)
                coinPositionY = ground + yDiff;
            if (yA - yHalfDiff <= middlePlayArea)
                coinPositionY = top - yDiff;

            Debug.Log($"Coin : {coinPositionX}, {coinPositionY}");
        }
        Vector2 coinSpawnPosition = new Vector2(coinPositionX, coinPositionY);
        GameObject spawnCoin = (GameObject)Instantiate(Resources.Load("Coin"), coinSpawnPosition, Quaternion.identity);
    }
}
