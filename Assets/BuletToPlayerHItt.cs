using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuletToPlayerHItt : MonoBehaviour
{
    private GameObject player;
    public float PlayerProximety = 0.1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < PlayerProximety)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("MainCharacter");

            PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.TakeDamage(10);
                selfDestruckt();
            }
        } 
    }
    private void selfDestruckt()
    {
        Destroy(gameObject);
    }




}
