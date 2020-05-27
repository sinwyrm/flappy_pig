using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPool : MonoBehaviour
{
    public int postPoolSize = 8;  // initialized variable for post pool size
    public GameObject postPrefab;  // declaring a GameObject array that will be used to call the Posts prefab
    public float spawnRate = 4f;  // initialized variable for rate at which posts will spawn
    public float postMinY = -2f;  // initialized variable to set lowest post placement limit
    public float postMaxY = 2f;  // initialized variable to set highest post placement limit
    public float postMinX = 10f;  // initialized variable to set closest a post can spawn at
    public float postMaxX = 15f;  // initialized variable to set farthest a post can spawn at
    public static float currentPostX = -10f;  // declare static variable to hold current X position
    public static float currentPostY = -10f;  // declare static variable to hold current Y position
    public static float lastPostX;  // declare static variable to hold last X position
    public static float lastPostY;  // declare static variable to hold last Y position

    private GameObject[] woodenPost;  // declaring new post array
    private Vector2 objectPoolPosition = new Vector2(-10f, -10f);  // initialized object pool position off-screen
    private float timeSinceLastSpawn;  // declared float variable to track time passed since last post spawn
    private int currentPost = 0;  // initialize variable to track posts in array




    void Start()
    {
        woodenPost = new GameObject[postPoolSize];  // set up array woodenPosts to size postPoolSize
        for (int i = 0; i < postPoolSize; i++)  // for loop set to array size
        {
            woodenPost[i] = (GameObject)Instantiate(postPrefab, objectPoolPosition, Quaternion.identity);
            // fill each spot in the array with an instantiated post, off-screen, with default rotation
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;  // adds time since last frame render to counter 

        if (GameControl.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
            // make sure game is not over AND spawnRate time has been exceeded...
        {
            timeSinceLastSpawn = 0;  // reset counter

            lastPostX = currentPostX;  // sets last X position before calculating new one
            lastPostY = currentPostY;  // sets last Y position before calculating new one

            float spawnYPosition = Random.Range(postMinY, postMaxY);  // sets a random Y position for new posts
            float spawnXPosition = Random.Range(postMinX, postMaxX);  // sets a random X position for new posts

            woodenPost[currentPost].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            // moves current post in array to new position off-screen ready to enter game

            currentPostX = spawnXPosition;  // sets new current X position to static variable
            currentPostY = spawnYPosition;  // sets new current Y position to static variable

            currentPost++;  // advance the array by one to get the next post ready
            if (currentPost >= postPoolSize)  // check if pool size has been exceeded
            {
                currentPost = 0;  // reset array counter to prepare to recycle assets
            }
        }
    }
}
