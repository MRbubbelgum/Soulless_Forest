using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : MonoBehaviour
{
    private float horizontalValue;
    private Rigidbody2D rb;
    private float walkSpeed = 5f;
    private Animator animator;
    private bool canWalk = true;
    public int maxHealth = 100;
    int currentHealth;
    private bool isDead = false;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalValue = rb.velocity.x;
        if (horizontalValue < -0.1f)
        {
            transform.localScale = new Vector3(-1.5f, transform.localScale.y, transform.localScale.z);
        }
        if (horizontalValue > 0.1f)
        {
            transform.localScale = new Vector3(1.5f, transform.localScale.y, transform.localScale.z);
        }
    }
    void FixedUpdate()
    {
        if (canWalk && !isDead)
        {
            rb.velocity = new Vector2(1 * (walkSpeed * 10) * Time.deltaTime, rb.velocity.y);
        }
        animator.SetFloat("isWalking", Mathf.Abs(rb.velocity.x));
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemySkeletonBlock"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            CannotWalk();
            Invoke("WaitThenReverseWalkSpeed", 3f);
        }
        if (other.gameObject.CompareTag("EnemySkeleton"))
        {
            WaitThenReverseWalkSpeed();
        }
    }
    private void WaitThenReverseWalkSpeed()
    {
        CanWalk();
        walkSpeed = -walkSpeed;
    }
    public void TakeDamageEnemy(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        Debug.Log("Damage TAKEN!");
        if(currentHealth < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        animator.SetTrigger("IsDead");
        canWalk = false;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        boxCollider2D.enabled = false;
        isDead = true;

    }
    private void CanWalk()
    {
        canWalk = true;
    }
    private void CannotWalk()
    {
        canWalk = false;
    }
    private void DisableScript()
    {
        this.enabled = false;
    }
}
