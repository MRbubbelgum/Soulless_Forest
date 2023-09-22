using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossRoom : MonoBehaviour
{
    [SerializeField] private GameObject EnterDoorText;
    [SerializeField] private GameObject bossRoomPlayerSpawn;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject musicPlayer;
    private BossMusic bossMusic;
    private bool textIsShowing = false;

    private void Start()
    {
      bossMusic = musicPlayer.GetComponent<BossMusic>();
    }
    private void Update()
    {
        if(textIsShowing && Input.GetKeyDown(KeyCode.E))
        {
            mainCharacter.transform.position = bossRoomPlayerSpawn.transform.position;
            bossMusic.ChangeSoundTrack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
          ActivateDoorText();
          CancelInvoke("InActivateDoorText");
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Invoke("InActivateDoorText", 0.5f);
        }
    }

    private void ActivateDoorText()
    {
        EnterDoorText.SetActive(true);
        textIsShowing = true;
    }
    private void InActivateDoorText()
    {
        EnterDoorText.SetActive(false);
        textIsShowing = false;
    }
}
