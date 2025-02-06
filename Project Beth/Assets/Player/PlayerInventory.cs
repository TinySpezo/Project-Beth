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
    public bool HasAbility<T>() where T : Ability
    {
        foreach (Ability ability in collectedAbilities)
        {
            if (ability is T)
                return true;
        }
        return false;
    }

    public void UseAbility<T>() where T : Ability
    {
        foreach (Ability ability in collectedAbilities)
        {
            if (ability is T)
            {
                ability.UseEffect(playerMovement);
                return;
            }
        }
        Debug.LogWarning("Diese Fähigkeit wurde noch nicht aufgesammelt!");
    }
}
