using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    private ItemDictionary itemDictionary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
        itemDictionary = FindFirstObjectByType<ItemDictionary>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //walking into the items - collecting
    {
        if (collision.CompareTag("Item")) //if it is the collectable item
        {
            Item item = collision.GetComponent<Item>();
            if(item != null)
            {
                //Add item to the inventory
                /*bool itemAdded = inventoryController.AddItem(collision.gameObject);
                if (itemAdded)
                {
                    Destroy(collision.gameObject); //disappear -picking up items
                }*/
                GameObject prefab = itemDictionary.GetItemPrefab(item.ID);
                if (prefab != null)
                {
                    bool itemAdded = inventoryController.AddItem(prefab);
                    if (itemAdded)
                    {
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
}
