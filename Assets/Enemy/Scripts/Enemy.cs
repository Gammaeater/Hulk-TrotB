using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator anim;
    public GameObject bloodEffect;
    public GameObject enemy;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // anim.SetBool

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Die();
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Destroy(bloodEffect, 2f);
        health -= damage;
        GetDamage();
        anim.SetTrigger("Hurt");

        gameObject.GetComponent<EnemyShot>().isAttacked = true;







    }
    void Die()
    {
        anim.SetBool("IsDead", true);
        gameObject.SetActive(false);

    }
    void GetDamage()
    {
        var magnitude = 500;
        // calculate force vector
        var force = transform.position - enemy.transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);

    }
}

