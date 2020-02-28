using UnityEngine;





[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    private float horizontalMove;
    public float chaseRaidus;
    public float attackRadius;
    public GameObject _target;
    private float moveSpeed;
    public LayerMask _playerLayer;
    public float speed;
    public float distance;
    public Transform groundDetection;
    public Transform objectDetection;
    public bool movingRight = true;
    public bool busy;
    public Collider2D _player;
    public Vector2 angle;
    public Vector3 targett;
    private float dazedTime;
    public float startDazedTime;
    public Rigidbody2D rb;
    public Vector2 direction;
    private bool isWall;
    private float radius = 0.1f;








    void Awake()
    {
        direction = Vector2.right;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (dazedTime <= 0)
        //{
        //    speed = 5;

        //}
        //else
        //{
        //    speed = 0;
        //    dazedTime -= Time.deltaTime;
        //}


        if (!busy)
        {

            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

            float horizontalMove = transform.position.x;
            anim.SetFloat("speed", Mathf.Abs(horizontalMove));

            int layer_mask = LayerMask.GetMask("Ground");


            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, layer_mask);
            if (groundInfo.collider == false)
            {
               
                if (movingRight == true)
                {
                    
                    direction = Vector2.left;
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    //spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;
                    movingRight = false;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);

                    movingRight = true;
                    direction = Vector2.right;
                }

            }
            RaycastHit2D groundInfoWall = Physics2D.Raycast(objectDetection.position, Vector2.right, layer_mask);
            if (groundInfoWall.collider == true)
            {


                if (movingRight == true)
                {

                    direction = Vector2.left;
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    //spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;
                    movingRight = false;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);

                    movingRight = true;
                    direction = Vector2.right;
                }
                //transform.eulerAngles = new Vector3(0, -180, 0);
            }






        }



    }
    public void KnockBack()
    {

        rb.AddForce(new Vector2(rb.position.x + 10, rb.position.y));


    }
    void OnTriggerStay2D(Collider2D _player)
    {

        if (_player.gameObject.tag == "Player")
        {
            busy = true;
            if (transform.position.x > _target.transform.position.x)
            {



            }
            else if (transform.position.x < _target.transform.position.x)
            {

                spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;

            }


            busy = true;
            anim.SetFloat("speed", 0);







        }
    }
    void OnTriggerExit2D(Collider2D other)
    {


        busy = false;
        gameObject.GetComponent<EnemyShot>().isAttacked = false;

    }
}
