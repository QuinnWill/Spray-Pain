using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomAIPath : MonoBehaviour
{
    public Transform target;
    IAstarAI ai;
    // Start is called before the first frame update
    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
