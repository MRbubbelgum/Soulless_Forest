using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }
    private void PlayHeartBeat()
    {
        audioSource.Play();
    }
}
