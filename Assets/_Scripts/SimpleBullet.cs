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
        if(player | wall)
            Destroy(gameObject);
    }
}
