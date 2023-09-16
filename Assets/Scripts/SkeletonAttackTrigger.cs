using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackTrigger : MonoBehaviour
{
    public bool mainCharacterInTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            mainCharacterInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            mainCharacterInTrigger = false;
        }
    }
}
