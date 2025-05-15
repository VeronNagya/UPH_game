using UnityEngine;
using UnityEngine.UIElements;

public class ShrineTrigger : MonoBehaviour
{
    private InventoryController inventory;
    public GameObject winPanel;
    private void Start()
    {
        inventory = FindFirstObjectByType<InventoryController>();
        /*if (winPanel != null)
        {
            winPanel.SetActive(false); //deactivates WinScreen
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player enter the shrine
        if (collision.CompareTag("Player"))
        {
            //InventoryController inventory = collision.GetComponent<InventoryController>();
            if (inventory != null && inventory.HasAllGems()) //all the gems are collected
            {
                if (!inventory.victoryTriggered) //blocks more calls
                {
                    inventory.TriggerVictory(); //launchs the WinScreen
                }
            }
            else
            {
                Debug.Log("You need all 5 gems to activate the shrine.");
                //Add a UI message here
            }
        }
    }
}
