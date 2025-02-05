using NUnit.Framework;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
    public bool IsOpened { get; private set; }
    //public string ChestID { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;

    public PlayerInventory playerInventory;
    void Start()
    {
        if (playerInventory == null)
        {
            playerInventory = FindFirstObjectByType<PlayerInventory>();
        }
    }
    public bool CanInteract()
    {
        return !IsOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        OpenChest();
    }

    private void OpenChest()
    {
        SetOpened(true);

        if (itemPrefab)
        {
            playerInventory.AddItem(itemPrefab);
        }
    }

    public void SetOpened(bool opened)
    {
        if (IsOpened = opened)
        { 
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
}
