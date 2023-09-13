using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageBlock : MonoBehaviour
{
    [SerializeField] private GameObject passageBlockText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            passageBlockText.SetActive(true);
            CancelInvoke("WaitUntilRemoveText");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            Invoke("WaitUntilRemoveText", 1f);
        }
    }
    private void WaitUntilRemoveText()
    {
        passageBlockText.SetActive(false);
    }
}
