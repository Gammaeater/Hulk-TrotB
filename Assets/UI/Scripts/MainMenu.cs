

using UnityEngine;
#if UNITY_EDITOR
#endif

using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0;
    }


    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");

        Time.timeScale = 1;

    }
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}


