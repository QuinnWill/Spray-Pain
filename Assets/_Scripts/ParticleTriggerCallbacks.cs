using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTriggerCallbacks : MonoBehaviour
{
    private void OnParticleTrigger()
    {
        Debug.Log("Triggered");
    }
}
