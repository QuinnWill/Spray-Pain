using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{


    public static InputManager instance;

    private PlayerInput playerInput;

    private void Awake()
    {

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInput = new PlayerInput();
    }

    #region Events
    public static event Action<Vector2> move;
    public static event Action dodge;
    public static event Action<Vector2> aim;
    public static event Action useStarted;
    public static event Action useEnded;
    #endregion

    #region EnableDisable
    /// <summary>
    /// enables all of the events created by the PlayerInput class
    /// </summary>
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Movement.Move.performed += context => MoveCall(context.ReadValue<Vector2>());
        playerInput.Movement.Dodge.performed += _ => DodgeCall();
        playerInput.Actions.Aim.performed += context => AimCall(context.ReadValue<Vector2>());
        playerInput.Actions.Use.started += _ => UseStartedCall();
        playerInput.Actions.Use.canceled += _ => UseEndedCall();

    }


    /// <summary>
    /// disables all of the events created by the PlayerInput class
    /// </summary>
    private void OnDisable()
    {
        playerInput.Movement.Move.performed -= context => MoveCall(context.ReadValue<Vector2>());
        playerInput.Movement.Dodge.performed -= _ => DodgeCall();
        playerInput.Actions.Aim.performed -= context => AimCall(context.ReadValue<Vector2>());
        playerInput.Actions.Use.started -= _ => UseStartedCall();
        playerInput.Actions.Use.canceled -= _ => UseEndedCall();
        playerInput.Disable();
    }
    #endregion


    #region EventCallFunctions
    private void MoveCall(Vector2 input)
    {
        move?.Invoke(input);
    }

    private void DodgeCall()
    {
        dodge?.Invoke();
    }

    private void AimCall(Vector2 input)
    {
        aim?.Invoke(input);
    }

    private void UseStartedCall()
    {
        useStarted?.Invoke();
    }

    private void UseEndedCall()
    {
        useEnded?.Invoke();
    }
    #endregion

}
