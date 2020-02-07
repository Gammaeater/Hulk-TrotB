using UnityEngine;
using System.Collections.Generic;
using System.Collections;





[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    private float horizontalMove;
    private float chaseRaidus;
    private float attackRadius;
    public GameObject _target;
    private float moveSpeed;

    public float speed;
    public float distance;
    public Transform groundDetection;
    public bool movingRight = true;




    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

         float horizontalMove = transform.position.x;
        anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        int layer_mask = LayerMask.GetMask("Ground");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, layer_mask);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }

    }

    public void CheckDistance()

    {


        if (Vector2.Distance(_target.transform.position, transform.position) <= chaseRaidus
            && Vector2.Distance(_target.transform.position, transform.position) > attackRadius)
        {

            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, moveSpeed * Time.deltaTime);

            
            
        }
    }
}
