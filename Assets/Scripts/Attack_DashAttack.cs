using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_DashAttack : MonoBehaviour
{
        /*
    void Start()
    {
        
    }
 
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                if (animator.GetBool("IsJumping"))
                {
                    animator.SetBool("IsJumping", false);
                }
                animator.SetTrigger("IsAttacking");
                nextAttackTime = Time.time + 1f / attackRate;
                nextDashAttackTime = Time.time + 1f / attackRate;

                if (mainCharacterScript.m_Grounded == true)
                {
                    playerMovementScript.runSpeed = 0f;
                }

                while (Time.time >= nextAttackTime)
                {
                    playerMovementScript.runSpeed = 0;
                }

            }
        }
        if (Time.time >= nextDashAttackTime)
        {
            if ((mainCharacterScript.m_Grounded == true && !animator.GetBool("IsCrouching") && playerMovementScript.crouch == false && playerMovementScript.jump == false && !animator.GetBool("IsJumping")))
            {
                if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Mouse1)))
                {
                    return;
                }
                else if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Mouse1)) || (Input.GetKey(KeyCode.D) && (Input.GetKeyDown(KeyCode.Mouse1))))
                {
                    animator.SetTrigger("IsDashAttacking");
                    playerMovementScript.runSpeed = 0f;

                    nextDashAttackTime = Time.time + 1f / dashAttackRate;
                    nextAttackTime = Time.time + 2f / attackRate;
                }
            }
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(attackDamage);
            }
        }
    }
    public void EndAttack()
    {
        IsAttacking = false;
        if (!IsAttacking)
        {
            playerMovementScript.runSpeed = 8f;
        }
    }

    void DashAttack()
    {
        if (!IsDashAttacking)
        {
            IsDashAttacking = true;



            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, dashAttackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(dashAttackDamage);
                }
            }


            if (Input.GetKey(KeyCode.D))
            {
                Vector3 dashDirection = transform.right.normalized;


                rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);


                StartCoroutine(StopDashingAfterDelay(0.5f));
            }

            else if (Input.GetKey(KeyCode.A))
            {
                Vector3 dashDirection = -transform.right.normalized;


                rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);


                StartCoroutine(StopDashingAfterDelay(0.5f));
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                return;
            }
        }



    }
    public void EndDashAttack()
    {
        IsDashAttacking = false;
        if (!IsDashAttacking && playerMovementScript.runSpeed == 0f)
        {
            playerMovementScript.runSpeed = 8f;
        }


    }
    private System.Collections.IEnumerator StopDashingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsDashAttacking = false;

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
