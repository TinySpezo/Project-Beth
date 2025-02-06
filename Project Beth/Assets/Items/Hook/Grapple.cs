using UnityEngine;

[CreateAssetMenu(fileName = "New Grappling Hook", menuName = "Ability/GrapplingHook")]
public class Grapple : Ability
{
    public GameObject hookPrefab; // Prefab des Hakens
    public float hookSpeed = 15f;
    public float pullSpeed = 10f;

    public override void ApplyEffect(PlayerMovement player)
    {
        player.EnableGrapplingHook();
    }
    public override void UseEffect(PlayerMovement player)
    {
        if (player != null)
        {
            player.LaunchGrapplingHook(hookPrefab, hookSpeed, pullSpeed);
        }
    }
}

