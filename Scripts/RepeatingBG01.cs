using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    private BoxCollider2D groundCollider;  // sets a reference to the ground's BoxCollider2D component
    private float groundHorizontalLength;  // declares a variable to store the background's length

    private void Awake ()
    {
        groundCollider = GetComponent<BoxCollider2D>();  // get and store the background's BoxCollider2D data
        groundHorizontalLength = groundCollider.size.x * 1.5f;  // set the length of the background to modified x
    }

    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)  // checks if object is off-screen
        {
            RepositionBackground();  // calls function to reposition the background
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);  // determines where to move off-screen BG to
        transform.position = (Vector2)transform.position + groundOffset;  // moves BG to other side of current BG
    }
}
