using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRepeat : MonoBehaviour
{
    private BoxCollider2D skyCollider;  // sets a reference to the sky's BoxCollider2D component
    private float skyHorizontalLength;  // declares a variable to store the sky's length

    private void Awake()
    {
        skyCollider = GetComponent<BoxCollider2D>();  // get and store the background's BoxCollider2D data
        skyHorizontalLength = skyCollider.size.x * 2.006f;  // set the length of the background to modified x
    }

    void Update()
    {
        if (transform.position.x < -skyHorizontalLength)  // checks if object is off-screen
        {
            RepositionBackground();  // calls function to reposition the background
        }
    }

    private void RepositionBackground()
    {
        Vector2 skyOffset = new Vector2(skyHorizontalLength * 2f, 0);  // determines where to move off-screen BG to
        transform.position = (Vector2)transform.position + skyOffset;  // moves BG to other side of current BG
    }
}
