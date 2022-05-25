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
    public static event Action useStart;
    public static event Action useEnd;
    public static event Action reloadStart;
    public static event Action reloadEnd;
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
        playerInput.Actions.Reload.started += _ => ReloadStartCall();
        playerInput.Actions.Reload.canceled += _ => ReloadEndCall();

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
        playerInput.Actions.Reload.started -= _ => ReloadStartCall();
        playerInput.Actions.Reload.canceled -= _ => ReloadEndCall();
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
        useStart?.Invoke();
    }

    private void UseEndedCall()
    {
        useEnd?.Invoke();
    }

    private void ReloadStartCall()
    {
        reloadStart.Invoke();
    }

    private void ReloadEndCall()
    {
        reloadEnd.Invoke();
    }
    #endregion

}
