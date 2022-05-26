using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSprayPaint : ASpraypaint
{

    public bool spraying;

    public Collider2D sprayCollider;

    public float ammoUsageRate;

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

        sprayCollider.enabled = false;

        ammo = maxAmmo;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        InputManager.useStart += Activate;
        InputManager.useEnd += Deactivate;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputManager.useStart -= Activate;
        InputManager.useEnd -= Deactivate;
    }

    // Update is called once per frame
    void Update()
    {
        if (spraying)
        {
            if (ammo > 0)
            {
                ammo -= ammoUsageRate * Time.deltaTime;
            }
            if (ammo < 0)
            {
                Deactivate();
                ammo = 0;
            }
        }
        else if (reloading)
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


    protected override void Activate()
    {
        if (!spraying && ammo > 0)
        {
            spraying = true;
            sprayCollider.enabled = true;
            paintParticles.Play();
        }
    }

    protected override void Deactivate()
    {
        if (spraying)
        {
            paintParticles.Stop();
            sprayCollider.enabled = false;
            spraying = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Trying to do damage");
        HealthSystem healthSystem = collider.GetComponent<HealthSystem>();
        Debug.Log(healthSystem);
        if (healthSystem)
        {
            healthSystem.AddHealth(-10 * Time.deltaTime);
        }
    }

    protected override void OnReloadStart()
    {
        base.OnReloadStart();
    }

    protected override void OnReloadEnd()
    {
        base.OnReloadEnd();
    }

}
