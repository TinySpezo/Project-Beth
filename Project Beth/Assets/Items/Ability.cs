using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite icon;

    public abstract void ApplyEffect(PlayerMovement player);
}
