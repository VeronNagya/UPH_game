using UnityEngine;

public class ChestScript : MonoBehaviour, InteractableInterface
{
    public bool IsOpened { get; private set; }
    public string ChestID { get; private set; }
    public GameObject itemPrefab; //Item the chest drops
    public Sprite openedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //unique ID
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject); //is not currently null
    }
    public bool CanInteract()
    {
        return !IsOpened; //it's not opened - can be open
    }

    public void Interact()
    {
        if (!CanInteract()) return; //it's opened - cannot be open again
        OpenChest();
    }
    private void OpenChest()
    {
        SetOpened(true);
        if (itemPrefab) //drop item
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
            droppedItem.GetComponent<BounceEffect>().StartBounce();
        }
    }
    public void SetOpened(bool opened)
    {
        IsOpened = opened;
        if (IsOpened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
}
