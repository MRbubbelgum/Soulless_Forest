using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject exitText;
    private GameObject lever;
    

    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
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
        if(other.CompareTag("MainCharacter") && Input.GetKey(KeyCode.E))
        {
            //playsound
            SceneManager.LoadScene("Level 2");
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
}

