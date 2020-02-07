using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attacPos;
    public float attacRange;
    public LayerMask whatISEnemies;
    public int damage;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey("[1]")))
        {
            attack = true;
            
            anim.SetTrigger("attack1");
            

        }
        else if ((Input.GetKey("[2]")))
        {
            attack = true;
            
            anim.SetTrigger("attack2");
        }
        else if ((Input.GetKey("[3]"))) //GetKey 
        {
            attack = true;
            
            anim.SetTrigger("Defense");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            attack = true;
            
            anim.SetTrigger("AttackCombo");
        }
        else if ((Input.GetKey("[4]"))) //GetKey 
        {
            attack = true;

            anim.SetTrigger("raw");
        }
        if (timeBtwAttack <= 0)
        {
            if ((attack))
            {
                //camAnim.setTrigger("shake");
                anim.SetTrigger("attack");
                Collider2D[] enemisToDamage = Physics2D.OverlapCircleAll(attacPos.position, attacRange, whatISEnemies);
                for (int i = 0; i < enemisToDamage.Length; i++)
                {
                     enemisToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    

                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            startTimeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attacPos.position, attacRange);

    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {

            anim.SetTrigger("attack1");


        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            anim.SetTrigger("attack2");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            anim.SetTrigger("Defense");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            anim.SetTrigger("AttackCombo");
        }
    }
}
