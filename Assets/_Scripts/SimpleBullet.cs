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
        var player = collision.collider.CompareTag("Player");
        var wall = collision.collider.CompareTag("Wall");
        var enemy = collision.gameObject.GetComponent<HealthSystem>();

        if (enemy & player)
        {
            enemy.AddHealth(-10);
        }

        if(player | wall)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.CompareTag("Player");
        var wall = collision.gameObject.CompareTag("Wall");
        var enemy = collision.gameObject.GetComponent<HealthSystem>();

        if (enemy & player)
        {
            enemy.AddHealth(-10);
        }

        if (player | wall)
            Destroy(gameObject);
        /*if (collision.gameObject.layer == 3)
        {
            var enemy = collision.GetComponent<HealthSystem>();

            if (enemy)
            {
                enemy.AddHealth(-10);
            }
            Destroy(gameObject);
        }*/

    }
}
