using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startPanel;
    private void Start()
    {
        if (startPanel != null)
        {
            startPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
