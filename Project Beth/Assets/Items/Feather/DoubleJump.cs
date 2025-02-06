using UnityEngine;

[CreateAssetMenu(fileName = "New Double Jump", menuName = "Ability/DoubleJump")]
public class DoubleJump : Ability
{
    public override void ApplyEffect(PlayerMovement player)
    {
        player.EnableDoubleJump();
    }
}
