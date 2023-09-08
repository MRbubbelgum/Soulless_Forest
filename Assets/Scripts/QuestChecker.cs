using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject doorTextBox, finishedText, unfinishedText;
    [SerializeField] private int keysAmount;
    [SerializeField] private int levelToLoad;
    [SerializeField] private GameObject Ebutton;

    private bool levelIsLoading = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                if (other.GetComponent<PlayerMovement>().keysCollected >= 3)
                {
                    Ebutton.SetActive(false);
                    doorTextBox.SetActive(true);
                    finishedText.SetActive(true);
                    Invoke("LoadNextLevel", 3f);
                    levelIsLoading = true;
                }
                else
                {
                    Ebutton.SetActive(false);
                    doorTextBox.SetActive(true);
                    unfinishedText.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Ebutton.SetActive(true);
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter") && !levelIsLoading)
        {
            Invoke("WaitUntilInactive", 3f);
        }
    }

    public void WaitUntilInactive()
    {
            doorTextBox.SetActive(false);
            finishedText.SetActive(false);
            unfinishedText.SetActive(false);
        Ebutton.SetActive(false);
    }
}
