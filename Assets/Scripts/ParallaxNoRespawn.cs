using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxNoRespawn : MonoBehaviour
{
    [SerializeField]
    private float parallaxSpeed;

    private Transform cameraTransform;
    private float startPositionX;
    private float spriteSizeX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionX = transform.position.x;
        

    }

    void Update()
    {
        float relativeDist = cameraTransform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPositionX + relativeDist, transform.position.y, transform.position.z);

        float relativeCameraDist = cameraTransform.position.x * (1 - parallaxSpeed);
        
    }
}
