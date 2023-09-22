using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bossMusic;
   
    public void ChangeSoundTrack()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(bossMusic, 0.2f);
    }
}
