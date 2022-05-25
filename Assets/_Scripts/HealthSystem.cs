using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float maxHealth {get; private set;}

    public float health;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            OnDeath();
        }
    }


    public void AddHealth(float addHealth)
    {
        health += addHealth;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
