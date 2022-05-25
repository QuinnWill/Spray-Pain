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

    void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.collider.GetComponent<SimpleEnemyAI>();
        if (enemy)
            enemy.TakeDamage(20);
        Destroy(gameObject);
    }
}
