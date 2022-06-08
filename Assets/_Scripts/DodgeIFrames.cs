using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeIFrames : MonoBehaviour
{

    public PlayerMovement movement;
    public HealthSystem playerHealth;
    public ASpraypaint[] paintToDisable;


    // Update is called once per frame
    void Update()
    {
        if (movement.state == PlayerMovement.State.Rolling)
        {
            playerHealth.canTakeDamage = false;
            foreach (ASpraypaint paint in paintToDisable)
            {
                paint.Deactivate();
            }
        }
        else if(!playerHealth.canTakeDamage)
        {
            playerHealth.canTakeDamage = true;
        }
    }
}
