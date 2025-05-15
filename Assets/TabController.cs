using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTab(0); //always opned to the first page
    }
    public void ActivateTab(int tabNo) //when clicked on the image of tabs
    {
        for(int i = 0; i < pages.Length; i++) //iterates through pages
        {
            pages[i].SetActive(false); //set all headhers to deactivated
            tabImages[i].color = Color.gray; //disabled = grayed
        }
        pages[tabNo].SetActive(true); //the one clicked on
        tabImages[tabNo].color = Color.white; //able = makes it transparet (the color it is)
    }
}
