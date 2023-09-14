using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPush : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isPlayingAudio = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter") && Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            if (isPlayingAudio == false)
            {
                audioSource.Play();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter") && Mathf.Abs(rb.velocity.x) <= 0f)
        {
            audioSource.Stop();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            audioSource.Stop();
        }
    }
}
