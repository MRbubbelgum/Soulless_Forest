using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool hit;

    private BoxCollider2D Boxcollider;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Boxcollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        Boxcollider.enabled = false;
    }
}
