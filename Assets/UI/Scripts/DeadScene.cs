
using UnityEngine;
#if UNITY_EDITOR
#endif

using UnityEngine.SceneManagement;


public class DeadScene : MonoBehaviour
{



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


