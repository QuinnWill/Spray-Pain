using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    Transform player;
    public LayerMask playerMask;
    public float movementSpeed, bulletSpeed;
    public float attackSpeed;
    public float attackRange;
    public float health;
    public float maxHealth = 100;
    bool playerInRange, alreadyAttacked;
    Vector3 pathDirection, bulletDirection;
    float maxDistance;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInRange)
            PathToPlayer();
        else
            AttackPlayer();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void PathToPlayer()
    {
        pathDirection = player.position - transform.position;
        pathDirection = pathDirection.normalized * Time.deltaTime * movementSpeed;
        maxDistance = Vector3.Distance(transform.position, player.position);
        transform.position += Vector3.ClampMagnitude(pathDirection, maxDistance);
    }

   void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            bulletDirection = player.position - transform.position;
            bulletDirection = bulletDirection.normalized;
            Rigidbody bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bullet.AddForce(bulletDirection * bulletSpeed, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(AttackReset), attackSpeed);
        }
    }

    void AttackReset()
    {
        alreadyAttacked = false;
    }
}
