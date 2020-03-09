using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager current;

    public List<ToxicBarrel> toxicBarrels;
    SceneFader sceneFader;
    public GameObject uAreDead;
    public float dethsequenceDuration = 1.5f;

    int numberOfDeath;
    float totalGameTime;
    bool isGameOver;
   

    
    // Start is called before the first frame update
    void Awake()
    {
        
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        uAreDead = GameObject.FindWithTag("uareDeadUI");
        //uAreDead.SetActive(false);
        toxicBarrels = new List<ToxicBarrel>();

        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGameOver)
            return;

        totalGameTime += Time.deltaTime;
    }

    public static bool IsGameOver()
    {
        if (current == null)
            return false;

        return current.isGameOver;
            
    }
    public static void PlayerDied()
    {
       
        if (current == null)
            return;
        //uAreDead.SetActive(true);

        current.numberOfDeath++;
        //UIManager.UpdateDeathUI(current.numberOfDeath);
        if (current.sceneFader != null)
            current.sceneFader.FadeSceneOut();

        current.Invoke("RestartScene", current.dethsequenceDuration);
    }
    public static void PlayerWon()
    {
        if (current == null)
            return;
        current.isGameOver = true;

    }
    public static void RegiesterToxicBarrel(ToxicBarrel toxicBarrel)
    {
        if (current == null)
            return;

        if (!current.toxicBarrels.Contains(toxicBarrel))
            current.toxicBarrels.Add(toxicBarrel);

       // UIManager.UpdateBarrelUI(current.toxicBarrels.Count);
    }

    public static void PlayerGrabBarrel(ToxicBarrel toxicBarrel)
    {
        if (current == null)
            return;

        if (!current.toxicBarrels.Contains(toxicBarrel))
            return;

        current.toxicBarrels.Remove(toxicBarrel);


       // if (current.toxicBarrels.Count == 0) 
           // current.lockedDoor.Open();

    }
    public static void RegisterSceneFader(SceneFader fader)
    {
        //If there is no current Game Manager, exit
        if (current == null)
            return;

        //Record the scene fader reference
        current.sceneFader = fader;
    }

    public void RestartScene()
    {
        toxicBarrels.Clear();
        //uAreDead.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //uAreDead.SetActive(false);


    }
}
