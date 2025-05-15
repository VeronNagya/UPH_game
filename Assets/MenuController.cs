using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject winPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false); //won't show right away
    }

    // Update is called once per frame
    void Update()
    {
        if (winPanel != null && winPanel.activeSelf) //won't open when the game is over (winPanel is active)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Tab)) //Tab key is used for interaction
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf); //set to what it currently is not
        }
    }
}
