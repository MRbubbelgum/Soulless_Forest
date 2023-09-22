using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRange : MonoBehaviour
{
    [SerializeField] private GameObject skeletonMovingPoints;
    [SerializeField] private GameObject mainCharacter;
    private PlayerMovement playerMovement;
    public bool isChasing = false;

    private void Start()
    {
        playerMovement = mainCharacter.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            isChasing = true;
            skeletonMovingPoints.SetActive(false);
        }
        else if(other.CompareTag("MainCharacter") && playerMovement.mainCharacterIsDead)
        {
            isChasing = false;
            skeletonMovingPoints.SetActive(true);
        }
    }
}
