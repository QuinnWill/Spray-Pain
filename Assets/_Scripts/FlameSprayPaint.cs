using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSprayPaint : ASpraypaint
{

    public bool spraying;

    [SerializeField]
    private ParticleSystem paintParticles;

    // Start is called before the first frame update
    void Awake()
    {
        if (!paintParticles)
        {
            paintParticles = GetComponentInChildren<ParticleSystem>();
            
        }
        paintParticles.Stop();
    }

    private void OnEnable()
    {
        InputManager.useStart += Activate;
        InputManager.useEnd += Deactivate;
    }

    private void OnDisable()
    {
        InputManager.useStart -= Activate;
        InputManager.useEnd -= Deactivate;
    }

    // Update is called once per frame
    void Update()
    {
        if (spraying)
        { 
            
        }
    }

    protected void Spray()
    { 
        
    }

    protected override void Activate()
    {
        if (!spraying)
        {
            spraying = true;
            paintParticles.Play();
        }
    }

    protected override void Deactivate()
    {
        if (spraying)
        {
            paintParticles.Stop();
            spraying = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trying to do damage");
    }

}
