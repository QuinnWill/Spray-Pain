using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpraypaint : MonoBehaviour
{
    public int ammo;

    public float reloadTime;
    public float activeReloadTime;



    protected abstract void Activate();

    protected abstract void Deactivate();
}
