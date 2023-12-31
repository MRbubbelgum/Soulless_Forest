using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject pullLeverText;
    [SerializeField] private GameObject somethingChangedText;
    [SerializeField] private AudioClip leverSound;
    private Animator animator;
    public bool hasPulledLever = false;
    private AudioSource soundEfect;

    void Start()
    {
        animator = GetComponent<Animator>();
        soundEfect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && hasPulledLever == false)
        {
            pullLeverText.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter") && Input.GetKey(KeyCode.E) && hasPulledLever == false)
        {
            animator.SetTrigger("PullLever");
            SoundEfect();
            pullLeverText.SetActive(false);
            CancelInvoke("WaitUntilRemoveText");
            Invoke("WaitUntilRemoveText2", 7f);
            hasPulledLever = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Invoke("WaitUntilRemoveText", 1f);
            
        }
    }
    private void WaitUntilRemoveText()
    {
        pullLeverText.SetActive(false);
    }
    private void WaitUntilRemoveText2()
    {
        somethingChangedText.SetActive(false);
    }
    public void SomethingHappenedText()
    {
        somethingChangedText.SetActive(true);
    }
    private void SoundEfect()
    {
        soundEfect.PlayOneShot(leverSound, 1f);
    }
}
