using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private ItemDictionary itemDictionary;
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    public List<string> collectedItems = new List<string>();
    public GameObject winPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindFirstObjectByType<ItemDictionary>();
        //initialize the slots and add the items to it
        for(int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>(); //Grabbing the slot GameObject and storing it here to work with it -test
            //Instantiate(slotPrefab, inventoryPanel.transform); //just to see the slots appering
            /*if(i < itemPrefabs.Length) //if the slot we are on fits the array of items
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform); //put the item in the slot
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //item is centered within the slot
                slot.currentItem = item;
            }*/
        }
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }
    public bool AddItem(GameObject itemPrefab)
    {
        //Look for an empty slot
        foreach(Transform slotTransform in inventoryPanel.transform) //for every slot inside the inventory panel
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if(slot != null && slot.currentItem == null) //do have a free slot
            {
                /*GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //centered in the middle of a slot
                slot.currentItem = newItem;
                Item itemComponent = itemPrefab.GetComponent<Item>();//
                if (itemComponent != null)//
                {
                    collectedItems.Add(itemComponent.itemName);
                }
                return true;*/
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                //Correct UI position setting
                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = Vector2.zero;
                    rectTransform.localScale = Vector3.one;
                    rectTransform.sizeDelta = new Vector2(80, 80); //size of image in the slot
                }
                //Checking rendering
                Image image = newItem.GetComponent<Image>();
                if (image != null)
                {
                    image.color = Color.white; //alpha != 0
                }
                slot.currentItem = newItem;
                Item itemComponent = itemPrefab.GetComponent<Item>();
                if (itemComponent != null && !collectedItems.Contains(itemComponent.itemName))
                {
                    collectedItems.Add(itemComponent.itemName);
                    //check for victory
                    /*if (HasAllGems())
                    {
                        TriggerVictory();
                    }*/ //now will only end the game after entering the shrine - not automaticlly after collecting all the gems
                }
                return true;
            }
        }
        Debug.Log("Inventory is full!");
        return false;
    }
    public bool HasAllGems()//
    {
        return collectedItems.Contains("Lumite - the crystal of spirit (The quiet presence that watches and binds.)") && //white
               collectedItems.Contains("Solite - the crystal of awakening (The first light that stirs leaf and soul.)") && //yellow
               collectedItems.Contains("Pyrite - the crystal of pulse (The restless fire in root and heart.)") && //red
               collectedItems.Contains("Verdite - the crystal of growth (The will to rise, twist, and renew.)") && //green
               collectedItems.Contains("Aetherite - the crystal of memory (The breath of time that sings through the trees.)"); //blue
    }
    [HideInInspector] public bool victoryTriggered = false;
    public void TriggerVictory()
    {
        if (victoryTriggered) return;
        victoryTriggered = true;
        if (winPanel != null && !winPanel.activeSelf) //launchs just once
        {
            winPanel.SetActive(true);
        }
        Time.timeScale = 0f; //zastavi hru
    }
}
