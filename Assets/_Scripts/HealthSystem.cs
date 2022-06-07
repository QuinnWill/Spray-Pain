using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float maxHealth;

    public float health;

    protected virtual void Start()
    {
        health = maxHealth;
    }
    protected virtual void Update()
    {
        if (health <= 0)
        {
            OnDeath();
        }
    }


    public virtual void AddHealth(float addHealth)
    {
        health += addHealth;
    }

    public virtual void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
