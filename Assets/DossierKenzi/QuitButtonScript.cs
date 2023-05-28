using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}