using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillColor;
    [SerializeField] private Image heart;
    [SerializeField] private Color greenHealth, redHealth;
    [SerializeField] private Color redHeart;
    [SerializeField] private TMP_Text keyTextUpdate;
    [SerializeField] private AudioClip hurtSound, healthPickupSound, keySound, runGrassSound;
    [SerializeField] private AudioClip[] jumpGrassSounds;
    [SerializeField] private GameObject appleParticals, dustParticles;

   public float runSpeed = 15f;
    public float jumpForce = 300f;
    private float horizontalValue;
    private float rayDistance = 0.1f;
    public bool canMove = true;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private int startingHealth = 100;
    public int currentHealth;
    private CapsuleCollider2D capsuleCollider;
    public int keysCollected = 0;
    private bool canPlayRunningSound = true;
    [SerializeField] private float runningSoundCooldown = 0.45f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        keyTextUpdate.text = "" + keysCollected;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        transform.position = spawnPosition.position;
       
    }

    private void Update()
    {   
        if(canMove)
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");
            if (horizontalValue < 0)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            if (horizontalValue > 0)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
        }
        


        if (Input.GetButtonDown("Jump") && (CheckIfGrounded() == true) && !animator.GetBool("Death"))
        {
            Jump();
            
        }

        else if (rb.velocity.y < -0.2 && (CheckIfGrounded() == false) && !animator.GetBool("IsHurting") && !animator.GetBool("Death"))
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else if (rb.velocity.y > 0.2 && (CheckIfGrounded() == false) && !animator.GetBool("IsHurting") && !animator.GetBool("Death"))
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if(Mathf.Abs(rb.velocity.x) > 2.5 && CheckIfGrounded() == true)
        {
            if (canPlayRunningSound)
            {
                audioSource3.PlayOneShot(runGrassSound, 1f);
                canPlayRunningSound = false; 
                StartCoroutine(EnableRunningSoundAfterCooldown());
            }

        }
        else
        {
            audioSource3.Stop();
        }
        
       
    }
    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        rb.velocity = new Vector2(horizontalValue * (runSpeed * 10) * Time.deltaTime, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Key"))
        {
            Destroy(other.gameObject);

            keysCollected++;
            keyTextUpdate.text = "" + keysCollected;
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(keySound, 0.13f);
        }
        if(other.CompareTag("Cherry"))
        {
            RestoreHealth(other.gameObject);
            
        }
    }
    public void Flip(bool direction)
    {
        spriteRenderer.flipX = direction;
    }
    private void Jump()
    {
        int randomValue = Random.Range(0, jumpGrassSounds.Length);
        audioSource.pitch = Random.Range(2.7f, 2.9f);
        
        audioSource.PlayOneShot(jumpGrassSounds[randomValue], 0.3f);
        Instantiate(dustParticles, transform.position, Quaternion.identity);
        rb.AddForce(new Vector2(0, jumpForce));
        animator.SetBool("IsJumping", true);
        
    }

    private IEnumerator EnableRunningSoundAfterCooldown()
    {
        yield return new WaitForSeconds(runningSoundCooldown);
        canPlayRunningSound = true; 
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();
        animator.SetTrigger("Hurt");
        
        audioSource2.PlayOneShot(hurtSound, 0.6f);
        animator.SetBool("IsHurting", true);
        if (currentHealth <= 0) 
        {
            Death();
        }
    }
    public void TakeKnockback(float knockbackForce, float knockupForce)
    {
        CantMove();
        rb.AddForce(new Vector2(knockbackForce, knockupForce));
        if(!animator.GetBool("Death"))
        {
            Invoke("CanMoveAgain", 0.25f);
        }
    }
    public void Death()
    {
        
        CantMove();
        animator.SetBool("Death", true);
        if(CheckIfGrounded() == true)
        {
            AfterDeath();
        }
        
    }
    public void AfterDeath()
    {
        rb.bodyType = RigidbodyType2D.Static;
        capsuleCollider.enabled = false;
        rb.velocity = new Vector2(0, 0);
        StartCoroutine(WaitUntilRespawn());
    }
    public IEnumerator WaitUntilRespawn()
    {
        yield return new WaitForSeconds(2);
        Respawn();
    }
    public void CanMoveAgain()
    {
        canMove = true;
        
    }
    public void CantMove()
    {
        canMove = false;
       
    }
    public void Respawn()
    {
        /* animator.SetBool("Death", false);
         capsuleCollider.enabled = true;
         transform.position = spawnPosition.position;
         CanMoveAgain();
         rb.bodyType = RigidbodyType2D.Dynamic;
         heart.color = Color.white;
         currentHealth = startingHealth;
         UpdateHealthBar(); */
        SceneManager.LoadScene(1);
    }

    public void RestoreHealth(GameObject cherry)
    {
        if(currentHealth >= startingHealth)
        {
            return;
        }
        else
        {
            int healthTorestore = cherry.GetComponent<Cherry>().healthValue;
            currentHealth += healthTorestore;
            UpdateHealthBar();
            Destroy(cherry);
            audioSource.pitch = Random.Range(2.7f, 2.9f);
            audioSource.PlayOneShot(healthPickupSound, 0.15f);
            Instantiate(appleParticals, cherry.transform.position, Quaternion.identity);
            if (currentHealth >= startingHealth)
            {
                currentHealth = startingHealth;
            }
        }
    }
    public void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
        if (currentHealth >= 40)
        {
            fillColor.color = greenHealth;
            heart.color = Color.white;
        }
        else
        {
            fillColor.color = redHealth;
            heart.color = redHeart;
        }
    }
    public void StartHurting()
    {
        CantMove();
        animator.SetBool("IsHurting", true);
    }
    public void StopHurting()
    {
        CanMoveAgain();
        animator.SetBool("IsHurting", false);
        
        

    }
    private bool CheckIfGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftFoot.position, Vector2.down, rayDistance, whatIsGround);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, Vector2.down, rayDistance, whatIsGround);
        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || (rightHit.collider != null && rightHit.collider.CompareTag("Ground")))
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}
