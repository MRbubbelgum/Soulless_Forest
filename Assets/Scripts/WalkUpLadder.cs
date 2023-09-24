using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUpLadder : MonoBehaviour
{
    [SerializeField] private GameObject walkUpLadderText;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject upperLadderSpawn;
    [SerializeField] private AudioClip ladderSound;
    private PassageBlock passageBlock;
    private bool ladderTextIsActive = false;
    private bool mainCharacterIsInsideTrigger = false;
    private AudioSource soundEfect;
    void Start()
    {
        passageBlock = GetComponent<PassageBlock>();
        soundEfect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter") && passageBlock.stoneIsRemoved == true)
        {
            Invoke("SetLadderTextActive", 0.5f);
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
            CancelInvoke("SetLadderTextActive");
        }
    }
    private void ClimbLadder()
    {
        mainCharacter.transform.position = upperLadderSpawn.transform.position;
        SoundEfect();
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
    private void SoundEfect()
    {
        soundEfect.PlayOneShot(ladderSound, 0.5f);
    }
}
