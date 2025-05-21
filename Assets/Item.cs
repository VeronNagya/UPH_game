using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string itemName;
    public Sprite itemIcon;
    private bool collected = false;
    public virtual void PickUp()
    {
        if (collected) return; //prevent double pickup
        collected = true;
        //Sprite itemIcon = GetComponent<Image>().sprite;
        if (ItemPickUpController.Instance != null)
        {
            ItemPickUpController.Instance.ShowItemPickup(itemName, itemIcon);
        }
    }
    public bool IsCollected()
    {
        return collected;
    }
}
