using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMouseLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
}
