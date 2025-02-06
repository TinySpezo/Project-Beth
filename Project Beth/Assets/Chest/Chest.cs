using NUnit.Framework;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
    public bool IsOpened { get; private set; }
    //public string ChestID { get; private set; }
    public Ability item;
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

        if (item)
        {
            playerInventory.AddItem(item);
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
