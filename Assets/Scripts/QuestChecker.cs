using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject doorTextBox, finishedText, unfinishedText;
    [SerializeField] private int keysAmount;
    [SerializeField] private int levelToLoad;

    private bool levelIsLoading = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            if(other.GetComponent<PlayerMovement>().keysCollected >= 3)
            {
                doorTextBox.SetActive(true);
                finishedText.SetActive(true);
                Invoke("LoadNextLevel", 3f);
                levelIsLoading = true;
            }
            else
            {
                doorTextBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
        }
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
    }
}
