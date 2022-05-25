using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMouseLookAt : MonoBehaviour
{

    public Vector2 aimPos;

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
        aimPos = input;
        
    }

    private void Update()
    {
        float angle = Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(aimPos) - transform.position);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
