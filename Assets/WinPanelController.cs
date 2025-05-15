using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelController : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; //if the game has been stopped
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("Quit requested"); //Only in Build
    }
}
