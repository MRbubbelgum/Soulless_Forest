using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkeleton : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Image fill;
    [SerializeField] private Image border;
    [SerializeField] private Slider skeletonHealthSlider;

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
        UpdateEnemyHealthBar();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        SetImageAlphaFill(0f);
        SetImageAlphaBorder(0f);
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

    private void UpdateEnemyHealthBar()
    {
        skeletonHealthSlider.value = currentHealth;
    }
    private void SetImageAlphaFill(float alphaValueFill)
    {
        Color imageColor = fill.color;
        imageColor.a = alphaValueFill;
        fill.color = imageColor;
    }
    private void SetImageAlphaBorder(float alphaValueBorder)
    {
        Color imageColorBorder = border.color;
        imageColorBorder.a = alphaValueBorder;
        border.color = imageColorBorder;
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
        UpdateEnemyHealthBar();
        animator.SetTrigger("Hurt");
        Debug.Log("Damage TAKEN!");
        if(currentHealth < maxHealth) 
        {
            SetImageAlphaFill(1f);
            SetImageAlphaBorder(1f);
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        fill.enabled = false;
        border.enabled = false;
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
