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
    //public static float currentPostY = -10f;  // declare static variable to hold current Y position
    public static float lastPostX;  // declare static variable to hold last X position
    //public static float lastPostY;  // declare static variable to hold last Y position
    public float postGap = -1f;  // initialized variable to set min. gap distance between spawned posts 

    private GameObject[] woodenPost;  // declaring new post array
    private Vector2 objectPoolPosition = new Vector2(-10f, -10f);  // initialized object pool position off-screen
    private float timeSinceLastSpawn;  // declared float variable to track time passed since last post spawn
    private int currentPost = 0;  // initialize variable to track posts in array
    private float spawnDifferenceX;  // variable to use in post gap calculations
    private float lastPostPositionY;
    private float newPostPositionY;

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
            //lastPostY = currentPostY;  // sets last Y position before calculating new one

            float spawnYPosition = Random.Range(postMinY, postMaxY);  // sets a random Y position for new posts
            float spawnXPosition = Random.Range(postMinX, postMaxX);  // sets a random X position for new posts

            currentPostX = spawnXPosition;  // sets new current X position to static variable
            //currentPostY = spawnYPosition;  // sets new current Y position to static variable

            spawnDifferenceX = currentPostX - lastPostX;  // determines gap between last post and current post

            if (spawnDifferenceX >= postGap)  // if gap required has been exceeded...
            {
                woodenPost[currentPost].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                // moves current post in array to new position off-screen ready to enter game
                Debug.Log("--------------------------------------------------------------------");
                Debug.Log("Post #0 = " + woodenPost[0].transform.position.x + ", " + woodenPost[0].transform.position.y);
                Debug.Log("Post #1 = " + woodenPost[1].transform.position.x + ", " + woodenPost[1].transform.position.y);
                Debug.Log("Post #2 = " + woodenPost[2].transform.position.x + ", " + woodenPost[2].transform.position.y);
                Debug.Log("Post #3 = " + woodenPost[3].transform.position.x + ", " + woodenPost[3].transform.position.y);
                Debug.Log("Post #4 = " + woodenPost[4].transform.position.x + ", " + woodenPost[4].transform.position.y);
                Debug.Log("Post #5 = " + woodenPost[5].transform.position.x + ", " + woodenPost[5].transform.position.y);
                Debug.Log("Post #6 = " + woodenPost[6].transform.position.x + ", " + woodenPost[6].transform.position.y);
                Debug.Log("Post #7 = " + woodenPost[7].transform.position.x + ", " + woodenPost[7].transform.position.y);
                Debug.Log("--------------------------------------------------------------------");

                currentPost++;  // advance the array by one to get the next post ready
                if (currentPost >= postPoolSize)  // check if pool size has been exceeded
                {
                    currentPost = 0;  // reset array counter to prepare to recycle assets
                }
            }
        }
    }
}
