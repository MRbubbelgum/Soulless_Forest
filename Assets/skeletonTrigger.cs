
using UnityEngine;

public class skeletonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject skeletonHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            skeletonHolder.SetActive(false);
        }
    }
}
