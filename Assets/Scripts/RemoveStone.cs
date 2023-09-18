using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStone : MonoBehaviour
{
    [SerializeField] private GameObject passageBlockText;
    [SerializeField] private GameObject magicRock;
    [SerializeField] private GameObject magicParticals;
    private PassageBlock passageBlock;
    private WalkUpLadder walkUpLadder;
    private bool mainCharacterIsInsideTrigger = false;
    private bool canSpawnParticals = true;
    private void Start()
    {
        magicRock.GetComponent<Transform>();
        passageBlock = GetComponent<PassageBlock>();
        walkUpLadder = GetComponent<WalkUpLadder>();
    }
    private void Update()
    {
        if (GetComponent<PassageBlock>().canPressE == true && Input.GetKeyDown(KeyCode.E) && mainCharacterIsInsideTrigger)
        {
            if(canSpawnParticals)
            {
                Quaternion magicRotation = magicRock.transform.rotation;
                Instantiate(magicParticals, new Vector3(magicRock.transform.position.x, 0.1f, -3f), magicRotation);
            }
            magicRock.SetActive(false);
            GetComponent<PassageBlock>().canPressE = false;
            passageBlock.stoneIsRemoved = true;
            passageBlockText.SetActive(false);
            walkUpLadder.SetLadderTextActive();
            canSpawnParticals = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            mainCharacterIsInsideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            mainCharacterIsInsideTrigger = false;
        }
    }
}

