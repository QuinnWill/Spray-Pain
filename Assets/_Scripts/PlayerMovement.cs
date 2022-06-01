using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float speed = 1;

    private Vector2 movementInput;

    private Vector2 rollInput;


    private void OnEnable()
    {
        InputManager.move += MoveInput;
        InputManager.dodge += DodgeInput;
    }

    private void OnDisable()
    {
        InputManager.move -= MoveInput;
        InputManager.dodge -= DodgeInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity /= 1.3f;
        rb.AddForce(movementInput * speed * 20);
    }

    private void MoveInput(Vector2 input)
    {
        movementInput = input;
    }

    private void DodgeInput()
    {
        rollInput = movementInput;
    }

}
