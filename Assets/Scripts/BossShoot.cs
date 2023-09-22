using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    private float timer;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if(distance > 2.5 ||  distance < 1.5)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
                
            }
        }
        
    }
    public void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        //anim.SetTrigger("Shoot");
    }

}
