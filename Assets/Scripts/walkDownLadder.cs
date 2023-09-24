using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkDownLadder : MonoBehaviour
{
    [SerializeField] private GameObject walkDownLadderText;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject lowerLadderSpawn;
    [SerializeField] private AudioClip ladderSound;

    private bool ladderTextIsActive = false;
    private bool mainCharacterIsInsideTrigger = false;
    private AudioSource soundEfect;

    private void Start()
    {
        soundEfect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Invoke("LadderTextActive", 0.5f);
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
            CancelInvoke("LadderTextActive");
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
        SoundEfect();
        Debug.Log("Climbed Down");
    }
    private void LadderTextActive()
    {
        walkDownLadderText.SetActive(true);
        ladderTextIsActive = true;
    }
    private void SoundEfect()
    {
        soundEfect.PlayOneShot(ladderSound, 0.1f);
    }
}
