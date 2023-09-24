using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHolderDisable : MonoBehaviour
{
    [SerializeField] private GameObject skeletonHolderCollider;


    private void InactivateSkeletonHolder()
    {
        skeletonHolderCollider.SetActive(false);
    }
}