using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State {
        Normal,
        Rolling,
    }

    public Rigidbody2D rb;

    public float speed = 1;

    private Vector2 movementInput;

    private Vector2 rollInput;

    private float rollSpeed;
    
    private State state;


    private void OnEnable()
    {
        InputManager.move += MoveInput;
        InputManager.dodge += DodgeInput;
        state = State.Normal;
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
        switch (state)
        {
            case State.Normal:
                break;
            case State.Rolling:
                float rollSpeedDivider = 6f;
                rollSpeed -= rollSpeed * rollSpeedDivider * Time.deltaTime;

                float rollSpeedMin = 5f;
                if (rollSpeed < rollSpeedMin)
                {
                    state = State.Normal;
                }
                break;
        }
    }
    

    private void FixedUpdate()
    {
        switch(state)
        {
            case State.Normal:
            rb.velocity /= 1.3f;
            rb.AddForce(movementInput * speed * 20);
            break;
        case State.Rolling:
            rb.velocity = rollInput * rollSpeed;
            break;
        }
    }

    private void MoveInput(Vector2 input)
    {
        movementInput = input;
    }

    private void DodgeInput()
    {
        rollInput = movementInput;
        rollSpeed = 30f;
        state = State.Rolling;
    }

}
