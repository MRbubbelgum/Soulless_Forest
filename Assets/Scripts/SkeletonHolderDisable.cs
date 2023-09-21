using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHolderDisable : MonoBehaviour
{
    [SerializeField] private GameObject skeletonHolderCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            skeletonHolderCollider.SetActive(false);
        }
    }
}
