using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<Vector3> spawnLocations;
    public GameObject enemy;
    public bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.CompareTag("Player");
        if (player & !hasSpawned)
        {
            foreach(Vector3 position in spawnLocations)
            {
                GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            }
            hasSpawned = true;
        }
        
    }
}
