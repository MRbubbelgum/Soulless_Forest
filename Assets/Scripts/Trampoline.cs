using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce = 200f;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            GetComponent<Animator>().SetTrigger("Move");
            Rigidbody2D mainCharacterRB = other.GetComponent<Rigidbody2D>();
            mainCharacterRB.velocity = new Vector2(mainCharacterRB.velocity.x, 0);
            mainCharacterRB.AddForce(new Vector2(0, jumpForce));
            
        }
    }
    
}
