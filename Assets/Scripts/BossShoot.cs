using UnityEngine;


public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    [SerializeField] public LayerMask attackMask;
    private float timer;
    public float attackShoot = 200.0f;
    public float attackRange = 1.0f;
    public int attackDamage = 20;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        
    }

    // Update is called once per frame
    void Update()
    {
        

        /*float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance >= attackShoot)
        {
            if (distance > 2.5 || distance < 1.5) ;
            {
                timer += Time.deltaTime;
                if (timer > 2)
                {
                    timer = 0;
                    Shoot();

                }
            }
        }*/

        
    }
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        
    }
}
