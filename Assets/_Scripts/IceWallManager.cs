using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log(Time.time - timeCreated);
        if (Time.time - timeCreated > 4)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
