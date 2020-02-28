using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Vector2 moveDirection;
    private Vector3 targetPos;
    private Vector3 thisPos;
    [SerializeField]
    private GameObject target;
    private float angle;
    public float TimeBetweenRangeShots;
    private float timeSinceLastRangeShot;
    public float bulletSpeed;
    public GameObject shot;
    public Transform attackPosition;
    public LayerMask whatISEnemies;
    public float attacRange;
    [SerializeField]
    public bool isAttacked { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        isAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        int player_layer_mask = LayerMask.GetMask("Player");

        if (distance < 10 && !isAttacked)
        {
            if (Time.time > timeSinceLastRangeShot + TimeBetweenRangeShots)
            {

                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attacRange, whatISEnemies);
                foreach (Collider2D enemy in enemies)
                {
                    
                    Shoot();
                }











                timeSinceLastRangeShot = Time.time;

            }




        }



    }

    public void Shoot()
    {
        //float offset = -90f;

        GameObject poisonBullet = Instantiate(shot, transform.position, Quaternion.identity);
        Rigidbody2D rbbullet2 = poisonBullet.GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rbbullet2.velocity = new Vector2(moveDirection.x, moveDirection.y);




        //targetPos = target.transform.position;
        //thisPos = rbbullet2.position;
        //targetPos.x = targetPos.x - thisPos.x;
        //targetPos.y = targetPos.y - thisPos.y;
        //angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        //rbbullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attacRange);

    }
}

