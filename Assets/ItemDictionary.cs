using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs; //will manually populate - include all items in the game
    private Dictionary<int, GameObject> itemDictionary; //to store itemPrefabs by their IDs

    private void Awake() //run before anything else
    {
        itemDictionary = new Dictionary<int, GameObject>();
        //AutoIncrementIDs
        for(int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i;
            }
        }
        foreach(Item item in itemPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }
    }
    public GameObject GetItemPrefab(int itemID)
    {
        //return itemDictionary[itemID]; //could crash
        itemDictionary.TryGetValue(itemID, out GameObject prefab);
        if(prefab == null)
        {
            Debug.LogWarning($"Item with ID {itemID} is not found in dictionary.");
        }
        return prefab;
    }
}
