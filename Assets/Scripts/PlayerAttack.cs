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
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
        originalAttackPosX = attackPos.position.x;
       
    }
  void Update()
{
        
        if (timeBtwAttack <= 0)
    {
            
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("AttackTrigger");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                foreach (Collider2D enemyCollider in enemiesToDamage)
                {
                    if (enemyCollider.CompareTag("EnemyMushroom"))
                    {

                        EnemyMushroom enemy = enemyCollider.GetComponent<EnemyMushroom>();
                        if (enemy != null)
                        {
                            enemy.TakeDamageEnemy(damage);
                        }
                    }
                }
            // Reset the attack cooldown timer immediately after triggering the attack
            timeBtwAttack = startTimeBtwAttack;
        }
    }
    else
    {
        timeBtwAttack -= Time.deltaTime;
    }
}
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }

