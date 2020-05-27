using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPool : MonoBehaviour
{
    public GameObject postPrefab;
    CoinSpawn newCoin = new CoinSpawn();


    public int postPoolSize = 8;  // post pool size
    public int spawnCoinAfter = 10; // spawn a coin after this many posts
    float spawnRate = 4f;
    public float spawnRateMin = 2f;
    public float spawnRateMax = 4f;

    public float postMinY = -0.947f;  // lowest post Y spawn position
    public float postMaxY = 3.305f;  // highest post Y spawn position

    public static float coinSpawnPositionX;
    public static float coinSpawnPositionY;
    public static float post1X;
    public static float post1Y;
    public static float post2X;
    public static float post2Y;


    private GameObject[] woodenPost;  // post array
    private Vector2 objectPoolPosition = new Vector2(-10f, -10f);

    private float timeSinceLastSpawn;
    private int currentPost = 0;
    private int thisPost;
    private int lastPost = 0;
    private int postCount = 1;

    void Start()
    {
        // set up wooden post object pool array
        woodenPost = new GameObject[postPoolSize];
        for (int i = 0; i < postPoolSize; i++)
        {
            woodenPost[i] = (GameObject)Instantiate(postPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // sets spawn time for next post
            
            float spawnYPosition = Random.Range(postMinY, postMaxY);  // sets a random Y position for new posts
            woodenPost[currentPost].transform.position = new Vector2(20f, spawnYPosition);

            thisPost = currentPost;
            lastPost = thisPost - 1;
            if (thisPost == 0)
                lastPost = postPoolSize - 1;
            post2X = woodenPost[thisPost].transform.position.x;
            post2Y = woodenPost[thisPost].transform.position.y;
            post1X = woodenPost[lastPost].transform.position.x;
            post1Y = woodenPost[lastPost].transform.position.y;

            // spawn a coin after a set amount of posts go by
            if (postCount - 1 == spawnCoinAfter)
            {
                postCount = 0;
                newCoin.SpawnCoin();
            }
            postCount++;
            currentPost++;
            if (currentPost >= postPoolSize)
                currentPost = 0;
        }
    }
}
