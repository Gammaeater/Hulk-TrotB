﻿using UnityEngine;





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





    void Awake()
    {


        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // CheckDistance();


        if (!busy)
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);

            float horizontalMove = transform.position.x;
            anim.SetFloat("speed", Mathf.Abs(horizontalMove));

            int layer_mask = LayerMask.GetMask("Ground");
            if (!busy)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, layer_mask);
                if (groundInfo.collider == false)
                {
                    if (movingRight == true)
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


                

                //int playerLayer_mask = LayerMask.GetMask("Player");
                //RaycastHit2D objectInfo = Physics2D.Raycast(objectDetection.position, Vector2.right, playerLayer_mask);
                //if (objectInfo.collider == _player)
                //{
                //    busy = true;
                //    //spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;
                //    anim.SetFloat("speed", 0);
                //    Debug.Log( "Player is Here");

                //    //anim.SetFloat("speed", 0);
                //}
                //else if(objectInfo.collider != _player)
                //{
                //    Debug.Log("I see no player");
                //    busy = false;
                //}

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
    void OnTriggerStay2D(Collider2D _player)
    {

        if (_player.gameObject.tag == "Player")
        {
            busy = true;
            if (transform.position.x > _target.transform.position.x)
            {
                // transform.rotation =
                Vector3 norTar = (targett - transform.position).normalized;
                float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
                // rotate to angle
                Quaternion rotation = new Quaternion
                {
                    eulerAngles = new Vector3(0, 0, angle - 90)
                };
                transform.rotation = rotation;
                

            }
            else if (transform.position.x < _target.transform.position.x)
            {
                transform.rotation = _target.transform.rotation;
            }

            busy = true;
            anim.SetFloat("speed", 0);
            //// get the angle






        }
    }
    void OnTriggerExit2D(Collider2D other)
    {


        //spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;
        
    }
}