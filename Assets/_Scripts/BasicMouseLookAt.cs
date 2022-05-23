using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMouseLookAt : MonoBehaviour
{


    private void OnEnable()
    {
        InputManager.aim += UpdateAim;
    }

    private void OnDisable()
    {
        InputManager.aim -= UpdateAim;
    }
   
    private void UpdateAim(Vector2 input)
    {
        float angle = Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(input));

        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(input)));
    }
}
