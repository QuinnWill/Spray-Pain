using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSprayPaint : ASpraypaint
{

    public bool spraying;

    public float ammoUsageRate;

    [SerializeField]
    private ParticleSystem paintParticles;

    [SerializeField]
    private Collider2D hitBox;

    // Start is called before the first frame update
    void Awake()
    {
        if (!paintParticles)
        {
            //paintParticles = GetComponentInChildren<ParticleSystem>();
            paintParticles = GetComponent<ParticleSystem>();
        }
        paintParticles.Stop();

        if (!hitBox)
        {
            hitBox = GetComponent<Collider2D>();
        }

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
            hitBox.enabled = true;
            paintParticles.Play();
        }
    }

    protected override void Deactivate()
    {
        if (spraying)
        {
            paintParticles.Stop();
            hitBox.enabled = false;
            spraying = false;
        }
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name + " staying in trigger");
        HealthSystem healthSystem = other.GetComponent<HealthSystem>();
        if (healthSystem)
        {
            healthSystem.AddHealth(-10 * Time.deltaTime);
        }
    }

    /*private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        Debug.Log("Triggered");
        //ParticleSystem.ColliderData enterData;
        
        int numEnter = paintParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter, out var enterData);
        Debug.Log(numEnter);
        for (int i = 0; i < numEnter; i++)
        {
            for (int j = 0; j < enterData.GetColliderCount(i); j++)
            {
                Collider2D enemyCollider = enterData.GetCollider(i, j).GetComponent<Collider2D>();
                Debug.Log(enemyCollider.name + " Taking Damage");
                HealthSystem healthSystem = enemyCollider.GetComponent<HealthSystem>();
                if (healthSystem)
                {
                    healthSystem.AddHealth(-100 * (enter[i].remainingLifetime / enter[i].startLifetime));
                }
            }
            
        }
    }*/

    protected override void OnReloadStart()
    {
        base.OnReloadStart();
    }

    protected override void OnReloadEnd()
    {
        base.OnReloadEnd();
    }

}
