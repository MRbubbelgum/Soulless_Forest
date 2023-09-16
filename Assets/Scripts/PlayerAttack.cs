using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private float horizontalValue;
    public float originalAttackPosX;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private Animator anim;
    private bool hasHitEnemy = false;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        originalAttackPosX = attackPos.position.x;
    }
      void Update()
      {
        
            if (timeBtwAttack <= 0)
            {
            
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    GetComponent<PlayerMovement>().CantMove();
                    ResetVelocity();
                    anim.SetTrigger("AttackTrigger");
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("IsAttacking"))
            {
                hasHitEnemy = false;
            }

      }
    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        foreach (Collider2D enemyCollider in enemiesToDamage)
        {
            if (enemyCollider.CompareTag("Enemy") && !hasHitEnemy)
            {

                EnemySkeleton enemy = enemyCollider.GetComponent<EnemySkeleton>();
                if (enemy != null)
                {
                    enemy.TakeDamageEnemy(damage);
                    hasHitEnemy = true;
                }
            }
        }
    }

    private void ResetVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


