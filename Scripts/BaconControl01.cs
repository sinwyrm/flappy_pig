using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconControl : MonoBehaviour
{
    private float top = 5.0f;
    private float ground = -2.662f;
    float baconY;
    float baconX;
    bool baconMoveUp = true;
    float baconMoveY = 0.1f;

    void Start()
    {
        baconMoveY = GameControl.baconMove;
    }

    void Update()
    {
        baconX = transform.position.x;
        baconY = transform.position.y;

        if (baconX <= -10)
            Destroy(gameObject);

        if (baconMoveUp == true)
        {
            transform.position = new Vector2(baconX, (baconY + baconMoveY));
            if (baconY + baconMoveY >= top - (2 * baconMoveY))
                baconMoveUp = false;
        }

        if (baconMoveUp != true)
        {
            transform.position = new Vector2(baconX, (baconY - baconMoveY));
            if (baconY - baconMoveY <= ground + (2 * baconMoveY))
                baconMoveUp = true;
        }

    }
}
