using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{

    public ASpraypaint[] paintAbilities;

    private int activeIndex;

    private void OnEnable()
    {
        InputManager.switchWeapon += SwitchAbility;
    }

    private void OnDisable()
    {
        InputManager.switchWeapon -= SwitchAbility;
    }

    private void Start()
    {
        if (paintAbilities != null)
        {
            paintAbilities = GetComponentsInChildren<ASpraypaint>();

            paintAbilities[0].active = true;

            for (int i = 1; i < paintAbilities.Length; i++)
            {
                paintAbilities[i].active = false;
            }
        }

    }

    public void SwitchAbility()
    {
        paintAbilities[activeIndex].active = false;
        activeIndex++;
        if (activeIndex > paintAbilities.Length - 1)
        {
            activeIndex = 0;
        }
        paintAbilities[activeIndex].active = true;
    }


}
