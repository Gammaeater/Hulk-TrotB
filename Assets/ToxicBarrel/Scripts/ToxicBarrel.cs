using UnityEngine;
public class ToxicBarrel : MonoBehaviour
{


    public GameObject explosionVFXPrefab;   //The visual effects for orb collection
    public Animator playerAnim;
    int playerLayer;
    void Start()
    {
        //Get the integer representation of the "Player" layer
        playerLayer = LayerMask.NameToLayer("Player");
        

        //Register this orb with the game manager
        GameManager.RegiesterToxicBarrel(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the collided object isn't on the Player layer, exit. This is more 
        //efficient than string comparisons using Tags
        if (collision.gameObject.layer != playerLayer)
        {
            return;
        }

        //The orb has been touched by the Player, so instantiate an explosion prefab
        //at this location and rotation
        playerAnim.SetTrigger("raw");
        Instantiate(explosionVFXPrefab, transform.position, transform.rotation);

        //Tell audio manager to play orb collection audio
       // AudioManager.PlayOrbCollectionAudio();

        //Tell the game manager that this orb was collected
        GameManager.PlayerGrabBarrel(this);


        //Deactivate this orb to hide it and prevent further collection
        gameObject.SetActive(false);
    }
}
