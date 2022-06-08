using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{


    public Animator animator;

    private void OnEnable()
    {
        InputManager.aim += ChangeAim;
    }

    private void OnDisable()
    {
        InputManager.aim += ChangeAim;
    }

    public void ChangeAim(Vector2 pos)
    {

        Vector2 aim = Camera.main.ScreenToWorldPoint(pos) - transform.position;

        animator.SetFloat("DirectionX", aim.x);

        animator.SetFloat("DirectionY", aim.y);

    }

}
