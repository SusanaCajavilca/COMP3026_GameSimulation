using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // based on lesson code
    public void StartGame()
    {
        SceneManager.LoadScene("PongGame"); // we have only 2 scenes, so no need to complicate this line
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
