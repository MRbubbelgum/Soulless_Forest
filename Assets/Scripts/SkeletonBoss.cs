
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private Image fill;
    [SerializeField] private Image border;
    [SerializeField] private Slider skeletonHealthSlider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip skeletonDeathSound;
    [SerializeField] private AudioClip[] skeletonDamageSounds;


    private float horizontalValue;
    private Rigidbody2D rb;
    private float walkSpeed = 5f;
    private Animator animator;
    private bool canWalk = true;
    public int maxHealth = 100;
    int currentHealth;
    private bool isDead = false;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private GameObject AttackTrigger;
    private SkeletonAttackTrigger skeletonAttackTrigger;
    [SerializeField] private GameObject skeletonTargetRange;
    private TargetRange targetRange;
    [SerializeField] private float chaseSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        skeletonAttackTrigger = AttackTrigger.GetComponent<SkeletonAttackTrigger>();
        targetRange = skeletonTargetRange.GetComponent<TargetRange>();
        currentHealth = maxHealth;
        UpdateEnemyHealthBar();


        SetColorInvisible();
        SetImageAlphaFill(0f);
        SetImageAlphaBorder(0f);
    }
    void FixedUpdate()
    {
        if (canWalk && !isDead && !targetRange.isChasing)
        {
            rb.velocity = new Vector2((walkSpeed * 10) * Time.deltaTime, rb.velocity.y);
        }
        else if (targetRange.isChasing && canWalk && !isDead)
        {
            Vector2 direction = (mainCharacter.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * (chaseSpeed * 10) * Time.deltaTime, rb.velocity.y);
        }
        animator.SetFloat("isWalking", Mathf.Abs(rb.velocity.x));
    }

    private void Update()
    {
        horizontalValue = rb.velocity.x; 
        if (horizontalValue < -0.1f)
        {
            transform.localScale = new Vector3(-1.4f, transform.localScale.y, transform.localScale.z);
        }
        if (horizontalValue > 0.1f)
        {
            transform.localScale = new Vector3(1.4f, transform.localScale.y, transform.localScale.z);
        }
        if (timeBtwAttack <= 0)
        {

            if (skeletonAttackTrigger.mainCharacterInTrigger == true)
            {
                SetColorVisable();
                CannotWalk();
                ResetVelocity();
                animator.SetBool("IsEnemyAttacking", true);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }
    public void SkeletonAttack()
    {
        Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        foreach (Collider2D playerCollider in playersToDamage)
        {
            if (playerCollider.CompareTag("MainCharacter"))
            {

                PlayerMovement player = playerCollider.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }
    }
    public void StopSkeletonAttack()
    {
        animator.SetBool("IsEnemyAttacking", false);
        SetColorInvisible();
        CanWalk();

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void UpdateEnemyHealthBar()
    {
        skeletonHealthSlider.value = currentHealth;
    }
    private void SetColorVisable()
    {
        Color currentColor = spriteRenderer.color;
        currentColor.a = 1f; 
        spriteRenderer.color = currentColor;
    }
    private void SetColorInvisible()
    {
        Color currentColor = spriteRenderer.color;
        currentColor.a = 0.1f;
        spriteRenderer.color = currentColor;
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
        int randomValue = Random.Range(0, skeletonDamageSounds.Length);
        AudioClip randomClip = skeletonDamageSounds[randomValue];
        audioSource.PlayOneShot(skeletonDamageSounds[randomValue], 0.22f);
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
        SetColorVisable();
        fill.enabled = false;
        border.enabled = false;
        animator.SetTrigger("IsDead");
        audioSource2.PlayOneShot(skeletonDeathSound, 0.45f);
        canWalk = false;
        ResetVelocity();
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
        ResetVelocity();
    }
    private void DisableScript()
    {
        this.enabled = false;
    }
    private void ResetVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
