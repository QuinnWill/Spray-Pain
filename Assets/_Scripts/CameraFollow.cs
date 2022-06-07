using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform trackedObject;

    private Vector3 lookDirection;


    private void OnEnable()
    {
        InputManager.aim += UpdateLookDIr;
    }

    private void OnDisable()
    {
        InputManager.aim -= UpdateLookDIr;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newPos = trackedObject.position + lookDirection.normalized * 3;
        newPos.z = transform.position.z;

        //transform.position = Vector3.Lerp(transform.position, newPos, 0.3f);
        transform.position = newPos;
    }

    public void UpdateLookDIr(Vector2 dir)
    {
        lookDirection = Camera.main.ScreenToWorldPoint(dir);
    }
}
