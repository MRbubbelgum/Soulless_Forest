using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    [SerializeField] private AudioClip hmmSound;
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            textPopUp.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(hmmSound, 0.5f);
        }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            Invoke("WaitUntilInactive", 3f);
        }
    }

    public void WaitUntilInactive()
    {
        textPopUp.SetActive(false);
    }

    
}
