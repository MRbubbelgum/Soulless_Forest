using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawnAbility : MonoBehaviour
{
    
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject skeletonSpawnPosition1;
    [SerializeField] private GameObject skeletonSpawnPosition2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SpawnTwoSkeletons();
        }
    }

    private void Start()
    {
        
    }
    private void SpawnSkeleton()
    {
        Instantiate(skeleton, new Vector3(skeletonSpawnPosition1.transform.position.x, skeletonSpawnPosition1.transform.position.y, 0), Quaternion.identity);
    }
    private void SpawnTwoSkeletons()
    {
        Instantiate(skeleton, new Vector3(skeletonSpawnPosition1.transform.position.x, skeletonSpawnPosition1.transform.position.y, 0), Quaternion.identity);
        Instantiate(skeleton, new Vector3(skeletonSpawnPosition2.transform.position.x, skeletonSpawnPosition2.transform.position.y, 0), Quaternion.identity);
    }
}
