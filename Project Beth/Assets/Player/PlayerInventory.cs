using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Ability> collectedAbilities = new List<Ability>();

    public PlayerMovement playerMovement;

    public void AddItem(Ability item)
    {
        Debug.Log("Power-Up erhalten: " + item.abilityName);
        item.ApplyEffect(playerMovement);
        collectedAbilities.Add(item);

    }
}
