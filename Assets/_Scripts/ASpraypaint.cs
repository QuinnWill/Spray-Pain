using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpraypaint : MonoBehaviour
{
    public float ammo;

    public float reloadTime;
    public float activeReloadTime;

    private float ammoPerSecond;

    protected virtual void Start()
    {
        ammoPerSecond = ammo / reloadTime;
    }

    protected abstract void Activate();

    protected abstract void Deactivate();
}
