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
        if ((Input.GetKey("[3]"))) //GetKey 
        {


            anim.SetTrigger("Defense");
        }
        else if ((Input.GetKey("[4]"))) //GetKey 
        {
            attack = true;

            anim.SetTrigger("raw");
        }




        //camAnim.setTrigger("shake");
        anim.SetTrigger("attack");
        Collider2D[] enemisToDamage = Physics2D.OverlapCircleAll(attacPos.position, attacRange, whatISEnemies);
        for (int i = 0; i < enemisToDamage.Length; i++)
        {


            if ((Input.GetKeyDown(KeyCode.Keypad1)))
            {

                attack = true;
                enemisToDamage[i].GetComponent<Enemy>().TakeDamage(1);
                anim.SetTrigger("attack1");
                damage = 1;

                //attack = false;

            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                attack = true;
                enemisToDamage[i].GetComponent<Enemy>().TakeDamage(2);
                damage = 2;

                anim.SetTrigger("attack2");
            }

            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                attack = true;

                enemisToDamage[i].GetComponent<Enemy>().TakeDamage(4);
                anim.SetTrigger("AttackCombo");
                
                if(enemisToDamage[i].GetComponent<EnemyMovment>().movingRight == true)
                {
                    enemisToDamage[i].GetComponent<Rigidbody2D>().AddForce(enemisToDamage[i].transform.position * 500 + (transform.forward * 500)* -1);
                }
                else if (enemisToDamage[i].GetComponent<EnemyMovment>().movingRight == false)
                {
                    enemisToDamage[i].GetComponent<Rigidbody2D>().AddForce(enemisToDamage[i].transform.position * 500 + (transform.forward * 500) );
                }
            }


        }
        timeBtwAttack = startTimeBtwAttack;

        anim.ResetTrigger("attack");




    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attacPos.position, attacRange);

    }


}
