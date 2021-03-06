using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpraypaint : MonoBehaviour
{

    public bool reloading;

    public bool active;

    public float maxAmmo;
    public float ammo;

    public float reloadTime;
    [Range(0,1)]
    public float inactiveReloadRatio;

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

    protected virtual void Update()
    {
        if (!reloading)
        {
            if (ammo < maxAmmo)
            {
                ammo += ammoPerSecond * inactiveReloadRatio * Time.deltaTime;
            }

            if (ammo > maxAmmo)
            {
                ammo = maxAmmo;
            }
        }
        else
        {
            if (ammo < maxAmmo)
            {
                ammo += ammoPerSecond * Time.deltaTime;
            }

            if (ammo > maxAmmo)
            {
                ammo = maxAmmo;
            }
        }
    }

    protected abstract void Activate();

    public abstract void Deactivate();

    protected virtual void OnReloadStart()
    {
        if (!active)
        {
            return;
        }

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
