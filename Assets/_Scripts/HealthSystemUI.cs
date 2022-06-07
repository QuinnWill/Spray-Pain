using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemUI : MonoBehaviour
{

    [SerializeField]
    private HealthSystem watchedHealth;

    private HeartUI[] hearts;

    void Start()
    {
        if (hearts == null)
        {
            hearts = GetComponentsInChildren<HeartUI>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetState(watchedHealth.health >= (i + 1) * 10);
        }
    }
}
