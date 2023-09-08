using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    [SerializeField] private AudioClip hmmSound;
    [SerializeField] private GameObject pressEText;
    private AudioSource audioSource;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            if (pressEText.activeSelf == true && Input.GetKey(KeyCode.E))
            {
                textPopUp.SetActive(true);
                pressEText.SetActive(false);
            }
                
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && pressEText.activeSelf == false && textPopUp.activeSelf == false)
        {
            pressEText.SetActive(true);
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
        pressEText.SetActive(false);
    }

    
}
