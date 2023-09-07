using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBridge : MonoBehaviour
{
    [SerializeField] private GameObject topButton; 
    private Animator animator;
    private bool hasPlayedAnimation = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && !hasPlayedAnimation)
        {
            hasPlayedAnimation = true;
            animator.SetTrigger("Move");
            topButton.SetActive(false);
        }
    }
}
