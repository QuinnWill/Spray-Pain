using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAttack : MonoBehaviour
{
    Transform player;
    public LayerMask playerMask;
    public float attackSpeed, attackRange, bulletSpeed;
    public bool playerInRange, alreadyAttacked;
    public Vector2 bulletDirection;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerMask = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, attackRange, playerMask);

        if (playerInRange)
            AttackPlayer();
    }
    void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            bulletDirection = player.position - transform.position;
            bulletDirection = bulletDirection.normalized;
            Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            bullet.AddForce(bulletDirection * bulletSpeed, ForceMode2D.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(AttackReset), attackSpeed);
        }
    }

    void AttackReset()
    {
        alreadyAttacked = false;
    }
}
