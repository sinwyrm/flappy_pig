using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPool : MonoBehaviour
{
    public int postPoolSize = 5;  // initialized variable for post pool size
    public GameObject postPrefab;  // declaring a GameObject array that will be used to call the Posts prefab
    public float spawnRate = 4f;  // initialized variable for rate at which posts will spawn
    public float postMin = -2f;  // initialized variable to set lowest post placement limit
    public float postMax = 2f;  // initialized variable to set highest post placement limit
    private GameObject[] woodenPost;  // declaring new post array
    private Vector2 objectPoolPosition = new Vector2(-10f, -10f);  // initialized object pool position off-screen
    private float timeSinceLastSpawn;  // declared float variable to track time passed since last post spawn
    private float spawnXPosition = 10f;  // initialize the X position for posts to spawn at
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
            float spawnYPosition = Random.Range(postMin, postMax);  // sets a random Y position for new posts
            woodenPost[currentPost].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            // moves current post in array to new position off-screen ready to enter game
            currentPost++;  // advance the array by one to get the next post ready
            if (currentPost >= postPoolSize)  // check if pool size has been exceeded
            {
                currentPost = 0;  // reset array counter to prepare to recycle assets
            }
        }
    }
}
