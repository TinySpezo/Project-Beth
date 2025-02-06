using UnityEngine;

[CreateAssetMenu(fileName = "New Grappling Hook", menuName = "Ability/GrapplingHook")]
public class Grapple : Ability
{
    public override void ApplyEffect(PlayerMovement player)
    {
        player.EnableGrapplingHook();
    }
}

