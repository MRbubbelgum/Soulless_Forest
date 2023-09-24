
using UnityEngine;

public class RemoveStone : MonoBehaviour
{
    [SerializeField] private GameObject passageBlockText;
    [SerializeField] private GameObject magicRock;
    [SerializeField] private GameObject magicParticals;
    [SerializeField] private AudioClip stonSound;
    private PassageBlock passageBlock;
    private WalkUpLadder walkUpLadder;
    private bool mainCharacterIsInsideTrigger = false;
    private bool canSpawnParticals = true;

    private AudioSource soundEfect;

    private void Start()
    {
        magicRock.GetComponent<Transform>();
        passageBlock = GetComponent<PassageBlock>();
        walkUpLadder = GetComponent<WalkUpLadder>();
        soundEfect = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (GetComponent<PassageBlock>().canPressE == true && Input.GetKeyDown(KeyCode.E) && mainCharacterIsInsideTrigger)
        {
            if(canSpawnParticals)
            {
                Quaternion magicRotation = magicRock.transform.rotation;
                Instantiate(magicParticals, new Vector3(magicRock.transform.position.x, 0.1f, -3f), magicRotation);
            }
            magicRock.SetActive(false);
            SoundEfect();
            GetComponent<PassageBlock>().canPressE = false;
            passageBlock.stoneIsRemoved = true;
            passageBlockText.SetActive(false);
            walkUpLadder.SetLadderTextActive();
            canSpawnParticals = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            mainCharacterIsInsideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            mainCharacterIsInsideTrigger = false;
        }
    }
    private void SoundEfect() 
    {
        soundEfect.PlayOneShot(stonSound, 1f);
    }
}

