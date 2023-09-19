using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkDownLadder : MonoBehaviour
{
    [SerializeField] private GameObject walkDownLadderText;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject lowerLadderSpawn;
   
    private bool ladderTextIsActive = false;
    private bool mainCharacterIsInsideTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Invoke("LadderTextActive", 2f);
            mainCharacterIsInsideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            walkDownLadderText.SetActive(false);
            ladderTextIsActive = false;
            mainCharacterIsInsideTrigger = false;
        }
    }
    private void Update()
    {
        if (ladderTextIsActive && Input.GetKeyDown(KeyCode.E) && mainCharacterIsInsideTrigger)
        {
            ClimbDownLadder();
        }
    }
    private void ClimbDownLadder()
    {
        mainCharacter.transform.position = lowerLadderSpawn.transform.position;
        Debug.Log("Climbed Down");
    }
    private void LadderTextActive()
    {
        walkDownLadderText.SetActive(true);
        ladderTextIsActive = true;
    }
}