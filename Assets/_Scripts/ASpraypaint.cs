using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpraypaint : MonoBehaviour
{

    public bool reloading;

    public float maxAmmo;
    public float ammo;

    public float reloadTime;
    public float activeReloadTime;

    protected float ammoPerSecond;

    protected virtual void Start()
    {
        ammoPerSecond = ammo / reloadTime;
    }

    protected virtual void OnEnable()
    {
        InputManager.reloadStart += OnReloadStart;
        InputManager.reloadEnd += OnReloadEnd;
    }

    protected virtual void OnDisable()
    {
        InputManager.reloadStart -= OnReloadStart;
        InputManager.reloadEnd -= OnReloadEnd;
    }

    protected abstract void Activate();

    protected abstract void Deactivate();

    protected virtual void OnReloadStart()
    {
        if (ammo < maxAmmo)
        {
            reloading = true;
        }

        Debug.Log("Reload Pressed");
    }

    protected virtual void OnReloadEnd()
    {
        reloading = false;
    }
}
