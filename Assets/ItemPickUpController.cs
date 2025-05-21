using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUpController : MonoBehaviour
{
    public static ItemPickUpController Instance { get; private set; } //any other script in game can access this script without havint to set a reference to it
    public GameObject popupPrefab;
    //public int maxPopups = 5;
    public float popupDuration = 3f;
    //private readonly Queue<GameObject> activePopups = new();
    public TMP_Text collectibleCounterText;
    public int totalCollectibles = 5;
    private int collectedCount = 0;
    private void Awake()
    {
        collectibleCounterText.gameObject.SetActive(false);
        if (Instance == null) //never run before
        {
            Instance = this; //storing a reference
        }
        else //there already is (shouldn't happend)
        {
            Destroy(gameObject);
        }
        UpdateCollectibleUI();
    }
    public void ShowItemPickup(string itemName, Sprite itemIcon)
    {
        collectedCount++;
        UpdateCollectibleUI();
        if (collectedCount >= totalCollectibles)
        {
            Debug.Log("You collected all items!");
        }
        GameObject newPopup = Instantiate(popupPrefab, transform); //appear inside the panel
        newPopup.GetComponentInChildren<TMP_Text>().text = "You gained " + itemName;

        /*Image itemImage = newPopup.transform.Find("ItemIcon")?.GetComponent<Image>();
        if (itemImage)
        {
            itemImage.sprite = itemIcon;
        }*/
        //activePopups.Enqueue(newPopup);
        /*if(activePopups.Count > maxPopups)
        {
            Destroy(activePopups.Dequeue()); //the oldest popUp
        }*/
        StartCoroutine(FadeOutAndDestroy(newPopup)); //fade out
    }
    public void ShowCollectibleUI()
    {
        if (collectibleCounterText != null)
        {
            collectibleCounterText.gameObject.SetActive(true);
        }
    }

    private void UpdateCollectibleUI()
    {
        if (collectibleCounterText != null)
        {
            collectibleCounterText.text = $"{collectedCount}/{totalCollectibles}";
        }
    }
    private IEnumerator FadeOutAndDestroy(GameObject popup)
    {
        yield return new WaitForSeconds(popupDuration); //waits on screen the popupDuration
        if (popup == null) yield break; //has been destroyed
        CanvasGroup canvasGroup = popup.GetComponent<CanvasGroup>();
        for(float timePassed = 0f; timePassed < 1f; timePassed += Time.deltaTime)
        {
            if (popup == null) yield break;
            //hasn't been destroyed
            canvasGroup.alpha = 1f - timePassed;
            yield return null;
        }
        Destroy(popup); //vanish at the end
    }
}
