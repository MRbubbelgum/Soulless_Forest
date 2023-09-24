using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject exitText;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private AudioClip doorSound;
    private GameObject lever;
    private AudioSource audioSource;
    

    void Start()
    {
        
        lever = GameObject.FindGameObjectWithTag("Lever");
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter") && lever.GetComponent<Lever>().hasPulledLever == true)
        {
            exitText.SetActive(true);
            CancelInvoke("WaitUntilRemoveText");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && Input.GetKey(KeyCode.E) && lever.GetComponent<Lever>().hasPulledLever == true)
        {
            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Invoke("WaitUntilRemoveText", 1f);
    }
    private void WaitUntilRemoveText()
    {
        exitText.SetActive(false);
    }
    private void SoundEfect()
    {
        audioSource.PlayOneShot(doorSound, 0.6f);
    }
}

