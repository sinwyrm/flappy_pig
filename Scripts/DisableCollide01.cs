using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollide : MonoBehaviour
{
    public Collider2D postCollider;

    private void Start()
    {
        postCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (FlappyPig.isPowerUp == true)
            postCollider.enabled = false;
        else
            postCollider.enabled = true;
    }
}
