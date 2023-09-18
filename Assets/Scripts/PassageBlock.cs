using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageBlock : MonoBehaviour
{
    [SerializeField] private GameObject passageBlockText;
    public bool canPressE = false;
    public bool stoneIsRemoved = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter") && stoneIsRemoved == false)
        {
            passageBlockText.SetActive(true);
            canPressE = true;
            Debug.Log("canpress E är true");
            
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
        canPressE = false;
    }
}
