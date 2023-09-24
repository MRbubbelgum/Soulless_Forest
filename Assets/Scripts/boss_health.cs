using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class boss_health : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Image fill;
    [SerializeField] private Image border;
    [SerializeField] private Slider skeletonHealthSlider;
    [SerializeField] private string sceneToLoad;
    private BoxCollider2D boxCollider;

    public int maxHealth = 100;
    int currentHealth;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void TakeDamageBoss(int damage)
    {
        currentHealth -= damage;
        UpdateEnemyHealthBar();
        
        Debug.Log("Damage TAKEN!");
       
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        fill.enabled = false;
        border.enabled = false;
        animator.SetBool("isDead", true);
    }
    private void UpdateEnemyHealthBar()
    {
        skeletonHealthSlider.value = currentHealth;
    }
    private void LoadeNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
