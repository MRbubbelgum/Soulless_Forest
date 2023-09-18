using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUpLadder : MonoBehaviour
{
    [SerializeField] private GameObject walkUpLadderText;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject upperLadderSpawn;
    private PassageBlock passageBlock;
    private bool ladderTextIsActive = false;
    private bool mainCharacterIsInsideTrigger = false;
    void Start()
    {
        passageBlock = GetComponent<PassageBlock>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter") && passageBlock.stoneIsRemoved == true)
        {
            SetLadderTextActive();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && passageBlock.stoneIsRemoved == true)
        {
            mainCharacterIsInsideTrigger = true;
            
        }
    }
    private void Update()
    {
        if(ladderTextIsActive && Input.GetKeyDown(KeyCode.E) && mainCharacterIsInsideTrigger)
        {
            ClimbLadder();
            ladderTextIsActive = false;
            walkUpLadderText.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            SetLadderTextInactive();
            mainCharacterIsInsideTrigger = false;
        }
    }
    private void ClimbLadder()
    {
        mainCharacter.transform.position = upperLadderSpawn.transform.position;
        Debug.Log("Climbed Up");
    }
    public void SetLadderTextActive()
    {
        ladderTextIsActive = true;
        walkUpLadderText.SetActive(true);
    }
    private void SetLadderTextInactive()
    {
        ladderTextIsActive = false;
        walkUpLadderText.SetActive(false);
    }
}
