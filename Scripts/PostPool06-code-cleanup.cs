using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPool : MonoBehaviour
{
    public GameObject postPrefab;

    public int postPoolSize = 8;  // post pool size
    public float spawnRate = 4f;  // post spawn rate

    public float postMinY = -0.947f;  // lowest post Y spawn position
    public float postMaxY = 3.305f;  // highest post Y spawn position

    public static float currentPostX = -10f;  // current post X position
    public static float currentPostY = -10f;  // current post Y position
    public static float lastPostX;  // last spawned post X position
    public static float lastPostY;  // last spawned post Y position

    private GameObject[] woodenPost;  // post array
    private Vector2 objectPoolPosition = new Vector2(-10f, -10f);  // object pool position off-screen

    private float timeSinceLastSpawn;  // declared float variable to track time passed since last post spawn
    private int currentPost = 0;  // initialize variable to track posts in array


    // ***TO DO***
    // swap out gap variance to a time variance
    //      - determine rate of post travel
    //      - set up random spawnRate
    //      - spawn posts at same X position but vary times
    public float postMinX = 10f;  // closest post X spawn position
    public float postMaxX = 15f;  // farthest post X spawn position
    public float postGap = -1f;  // initialized variable to set min. gap distance between spawned posts
    private float spawnDifferenceX;  // variable to use in post gap calculations

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

            lastPostX = currentPostX;
            lastPostY = currentPostY;

            float spawnYPosition = Random.Range(postMinY, postMaxY);  // sets a random Y position for new posts
            // ***TO DO***
            //      - change out random X for random spawnRate
            float spawnXPosition = Random.Range(postMinX, postMaxX);  // sets a random X position for new posts

            currentPostX = spawnXPosition;
            currentPostY = spawnYPosition;
            // ***TO DO***
            //      - eliminate this section after random spawnRate is calculated
            spawnDifferenceX = currentPostX - lastPostX;
            if (spawnDifferenceX >= postGap)
            {
                woodenPost[currentPost].transform.position = new Vector2(spawnXPosition, spawnYPosition);
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

                currentPost++;
                if (currentPost >= postPoolSize)
                    currentPost = 0;
            }
        }
    }
}
