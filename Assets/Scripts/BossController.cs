using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossAttacks bossAttacks;
    public BossShoot bossShoot;

    public float attackShoot = 200.0f;
    private Transform player;
    private float attackCooldown = 2f;
    private float lastAttackTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter").transform;
        
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackShoot)
        {
            if (distance > 2.5f)
            {
                // Use ranged attack when player is far away
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    bossShoot.Shoot();
                    lastAttackTime = Time.time;
                }
            }
        } 
           
    }
}
