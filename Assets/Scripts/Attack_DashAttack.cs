using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_DashAttack : MonoBehaviour
{
   
    /*
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
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

                if (playerMovement.CheckIfGrounded() == true)
                {
                    playerMovement.runSpeed = 0f;
                }

                while (Time.time >= nextAttackTime)
                {
                    playerMovement.runSpeed = 0;
                }

            }
        }
        if (Time.time >= nextDashAttackTime)
        {
            if ((playerMovement.CheckIfGrounded() == true && !animator.GetBool("IsCrouching") && !animator.GetBool("IsJumping")))
            {
                if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Mouse1)))
                {
                    return;
                }
                else if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Mouse1)) || (Input.GetKey(KeyCode.D) && (Input.GetKeyDown(KeyCode.Mouse1))))
                {
                    animator.SetTrigger("IsDashAttacking");
                    playerMovement.runSpeed = 0f;

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
            playerMovement.runSpeed = 8f;
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
        if (!IsDashAttacking && playerMovement.runSpeed == 0f)
        {
            playerMovement.runSpeed = 8f;
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
      