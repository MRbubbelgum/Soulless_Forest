using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestCheck2 : MonoBehaviour
{
    [SerializeField] private GameObject doorTextBox, finishedText, unfinishedText;
    [SerializeField] private int keysAmount;
    [SerializeField] private int levelToLoad;
    [SerializeField] private GameObject Ebutton;
    [SerializeField] private GameObject enterTowerText;

    private bool levelIsLoading = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            if (Input.GetKey(KeyCode.E) && enterTowerText.activeSelf == false)
            {
                if (other.GetComponent<PlayerMovement>().keysCollected >= 3)
                {
                    Ebutton.SetActive(false);
                    doorTextBox.SetActive(true);
                    finishedText.SetActive(true);
                    // Invoke("LoadNextLevel", 3f);
                    // levelIsLoading = true;
                    Invoke("WaitUntilEnterTower", 2f);
                }
                else
                {
                    Ebutton.SetActive(false);
                    doorTextBox.SetActive(true);
                    unfinishedText.SetActive(true);
                }
            }
            else if (Input.GetKey(KeyCode.E) && enterTowerText.activeSelf == true)
            {
                LoadNextLevel();
                levelIsLoading = true;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Ebutton.activeSelf == false)
        {
            Ebutton.SetActive(true);
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Tower");
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
        enterTowerText.SetActive(false);
    }
    public void WaitUntilEnterTower()
    {
        doorTextBox.SetActive(false);
        finishedText.SetActive(false);
        enterTowerText.SetActive(true);

    }
}
