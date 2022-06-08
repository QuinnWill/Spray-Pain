using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class IceWallManager : MonoBehaviour
{

    float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
    }

    public void AtFrameZero()
    {
        if (Time.time - timeCreated > 0.1f)
        {
            Destroy(transform.parent.gameObject);
            AstarPath.active.Scan();
        }
    }
}
