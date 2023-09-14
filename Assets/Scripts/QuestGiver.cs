using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    [SerializeField] private GameObject pressEText;
    [SerializeField] private GameObject questDetailsText;
    [SerializeField] private GameObject forestStoryText;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip hmmSound;
    [SerializeField] private AudioClip questDetailsSound;
    [SerializeField] private AudioClip forestStoryAndQuestDetailsSound;
    private bool insideTrigger = false;

    private void Update()
    {
        if (insideTrigger == true)
        {
            if (pressEText.activeSelf == true && Input.GetKey(KeyCode.E))
            {
                pressEText.SetActive(false);
                textPopUp.SetActive(true);
            }
            else if (textPopUp.activeSelf == true && Input.GetKeyDown(KeyCode.E))
            {
                textPopUp.SetActive(false);
                questDetailsText.SetActive(true);
                audioSource2.PlayOneShot(questDetailsSound);
            }
            else if (textPopUp.activeSelf == true && Input.GetKeyDown(KeyCode.Q))
            {
                textPopUp.SetActive(false);
                forestStoryText.SetActive(true);
                questDetailsText.SetActive(true);
                audioSource2.PlayOneShot(forestStoryAndQuestDetailsSound);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
       /* if (other.CompareTag("MainCharacter"))
        {
            if (pressEText.activeSelf == true && Input.GetKey(KeyCode.E))
            {
                pressEText.SetActive(false);
                textPopUp.SetActive(true);
            }
            else if (textPopUp.activeSelf == true && Input.GetKeyDown(KeyCode.E))
            {
                textPopUp.SetActive(false);
                questDetailsText.SetActive(true);
                audioSource2.PlayOneShot(questDetailsSound);
            }
            else if (textPopUp.activeSelf == true && Input.GetKeyDown(KeyCode.Q))
            {
                textPopUp.SetActive(false);
                forestStoryText.SetActive(true);
                questDetailsText.SetActive(true);
                audioSource2.PlayOneShot(forestStoryAndQuestDetailsSound);
            }

        } */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && pressEText.activeSelf == false && textPopUp.activeSelf == false && questDetailsText.activeSelf == false && forestStoryText.activeSelf == false)
        {
            insideTrigger = true;
            pressEText.SetActive(true);
            audioSource1.PlayOneShot(hmmSound);
            CancelInvoke("WaitUntilInactive");
        } 
        else if(other.CompareTag("MainCharacter"))
        {
            CancelInvoke("WaitUntilInactive");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Invoke("WaitUntilInactive", 8f);
        }
    }

    public void WaitUntilInactive()
    {
        insideTrigger = false;
        textPopUp.SetActive(false);
        pressEText.SetActive(false);
        questDetailsText.SetActive(false);
        forestStoryText.SetActive(false);
        audioSource2.Stop();
    }

    
}
