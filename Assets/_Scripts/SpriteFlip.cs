using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    public Pathfinding.AIPath aIPath;

    // Update is called once per frame
    void Update()
    {
        if(aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector2(-1f, 1f);
        } else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
