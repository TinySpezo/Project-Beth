using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<GameObject> inventory;

    public void AddItem(GameObject item)
    {
        inventory.Add(item);
        Debug.Log(inventory);
    }
    /*
    private void ClearInventory()
    {
        inventory.Clear();
    }

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += ClearInventory;
    }
    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= ClearInventory;
    }
    */
}
