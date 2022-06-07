using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<HealthSystem>();

        if (enemy)
        {
            enemy.AddHealth(-10);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            var enemy = collision.GetComponent<HealthSystem>();

            if (enemy)
            {
                enemy.AddHealth(-10);
            }
            Destroy(gameObject);
        }

    }
}
