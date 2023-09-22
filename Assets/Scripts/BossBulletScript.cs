using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private GameObject mainCharacter;
    private Rigidbody2D  rb;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacter");

        Vector3 direction = mainCharacter.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        //float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //transform.rotation = quaternion.Euler(0,0,rot+47);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
