using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attacPos;
    public float attacRange;
    public LayerMask whatISEnemies;
    public int damage;
    public bool attack;



    // Start is called before the first frame update
    void Awake()
    {
        attack = false;

    }

    // Update is called once per frame
    void Update()
    {




        Attack();
        Defense();
        Shout();








    }

    public void Attack()
    {
        anim.SetTrigger("attack");
        Collider2D[] enemisToDamage = Physics2D.OverlapCircleAll(attacPos.position, attacRange, whatISEnemies);
        foreach (Collider2D enemy in enemisToDamage)
        {


            if ((Input.GetKeyDown(KeyCode.Keypad1)))
            {

                attack = true;
                enemy.GetComponent<Enemy>().TakeDamage(1);
                anim.SetTrigger("attack1");


                //attack = false;

            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                attack = true;
                enemy.GetComponent<Enemy>().TakeDamage(2);
                

                anim.SetTrigger("attack2");
            }

            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {

                attack = true;

                enemy.GetComponent<Enemy>().TakeDamage(4);
                anim.SetTrigger("AttackCombo");

                if (enemy.GetComponent<EnemyMovment>().transform.position.x > transform.position.x)
                {
                    enemy.GetComponent<Rigidbody2D>().AddForce(enemy.transform.position * 500 + (transform.right * 500) * 1);
                }
                else if (enemy.GetComponent<EnemyMovment>().transform.position.x < transform.position.x)
                {
                    //  enemisToDamage[i].GetComponent<Rigidbody2D>().AddForce(enemisToDamage[i].transform.position * 500 + (transform.forward * 500) * -1 );
                }
            }


        }
        timeBtwAttack = startTimeBtwAttack;

        // anim.ResetTrigger("attack");

    }
    public void Defense()
    {
        if ((Input.GetKey("[3]"))) //GetKey 
        {


            anim.SetTrigger("Defense");
        }
    }

    public void Shout()
    {
        if ((Input.GetKey("[4]")))
        {
            attack = true;

            anim.SetTrigger("raw");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attacPos.position, attacRange);

    }


}
