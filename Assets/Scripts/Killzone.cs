using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("MainCharacter"))
        {
            StartCoroutine(other.gameObject.GetComponent<PlayerMovement>().WaitUntilRespawn());
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<PlayerMovement>().CantMove();
            
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
