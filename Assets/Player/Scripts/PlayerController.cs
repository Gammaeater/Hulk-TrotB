﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float heroSpeed;
    public float jumpForce;
    private float radius = 0.1f;
    private bool onTheGround;

    private bool directiontoRight = true;
    public Transform groundTester;
    public LayerMask layersToTest;
    public Animator anim;
    public Rigidbody2D rgBody;
    public Transform startPoint;
    public GameObject enemy;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rgBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layersToTest);
        float horizontalMove = Input.GetAxis("Horizontal");
       

        rgBody.velocity = new Vector2(horizontalMove * heroSpeed, rgBody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rgBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");


        }
        if (onTheGround)
        {
            anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        }

        if (horizontalMove < 0 && directiontoRight)
        {
            Flip();
        }
        if (horizontalMove > 0 && !directiontoRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        directiontoRight = !directiontoRight;
        Vector3 hereoScale = gameObject.transform.localScale;
        hereoScale.x *= -1;
        gameObject.transform.localScale = hereoScale;

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case ("BulletPoison"):
                //heroSpeed = 0;
                anim.SetTrigger("isAttacked");
                // how much the character should be knocked back
                var magnitude = 2000;
                // calculate force vector
                var force = transform.position - enemy.transform.position;
                // normalize force vector to get direction only and trim magnitude
                force.Normalize();
                gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
                Destroy(col.gameObject);
                break;

        }

    }
}
