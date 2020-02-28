using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public bool isAlive = true;
    public bool damaged;
    public LayerMask trapsLayer;
    public GameObject deathFXPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        trapsLayer = LayerMask.NameToLayer("Traps");
        Debug.Log(trapsLayer);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != trapsLayer || !isAlive)
            return;


        Debug.Log("Active Collisio neffect");
        Instantiate(deathFXPrefab, transform.position, transform.rotation);
        isAlive = false;
        gameObject.SetActive(false);
        GameManager.PlayerDied();
        //AudioManager.PlayDeathAudio();



    }
    public void TakeDamage(int amount)
    {

        damaged = true;


        currentHealth -= amount;


        healthSlider.value = currentHealth;





        if (currentHealth <= 0 && isAlive)
        {

            Death();
        }
    }
    void Death()
    {

        isAlive = false;





        // anim.SetTrigger("Die");



        // Turn off the movement and shooting scripts.

    }
}
