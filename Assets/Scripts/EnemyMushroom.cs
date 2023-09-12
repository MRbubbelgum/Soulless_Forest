using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour
{
    [SerializeField] private float runSpeed = 20f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private int damageGiven = 40;
    [SerializeField] private float knockbackForce = 400f;
    [SerializeField] private float knockupForce = 100f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mushroomDeathSound;
    [SerializeField] private int health = 2;


    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        // transform.Translate(new Vector2(runSpeed, 0) * Time.deltaTime);
        rb.velocity = new Vector2(1 * (runSpeed * 10) * Time.deltaTime, rb.velocity.y);
        if (runSpeed > 0)
    {
            spriteRenderer.flipX = false;
        }
        if(runSpeed < 0)
    {
            spriteRenderer.flipX = true;
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if(health <= 0)
        {
            die();
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("EnemyMushroomBlock"))
        {
            runSpeed = -runSpeed;
        }
        if (other.gameObject.CompareTag("EnemyMushroom"))
        {
            runSpeed = -runSpeed;
        }
        if(other.gameObject.CompareTag("MainCharacter"))
        {
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(damageGiven);
            if(other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<PlayerMovement>().TakeKnockback(knockbackForce, knockupForce);
            }
            else
            {
                other.gameObject.GetComponent<PlayerMovement>().TakeKnockback(-knockbackForce, knockupForce);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            audioSource.PlayOneShot(mushroomDeathSound, 0.35f);
            /*other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            other.GetComponent<PlayerMovement>().runSpeed = 15f;*/
            animator.SetBool("IsDead", true);
            
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            boxCollider.enabled = false;
            circleCollider.enabled = false;
            this.enabled = false;
        }
    }
    public void TakeDamageEnemy(int damage)
    {
        health -= damage;
        Debug.Log("Damage TAKEN!");
    }
    public void die()
    {
        audioSource.PlayOneShot(mushroomDeathSound, 0.35f);
        rb.velocity = Vector2.zero;
        animator.SetBool("IsDead", true);
        rb.gravityScale = 0;
        boxCollider.enabled = false;
        circleCollider.enabled = false;
    }

}
