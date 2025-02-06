using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GrapplingHook : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement player;
    private float speed;
    private float pullSpeed;
    private bool hasHit = false;

    public void Initialize(PlayerMovement player, float speed, float pullSpeed)
    {
        this.player = player;
        this.speed = speed;
        this.pullSpeed = pullSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * this.speed; // Haken nach vorne schieﬂen
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        if (other.CompareTag("Wood"))
        {
            hasHit = true;
            rb.linearVelocity = Vector2.zero;
            StartCoroutine(player.PullToPosition(transform.position, pullSpeed));
            Destroy(gameObject, 1f);
        }
        
        
        //Dat schlecht das musss auf zeit 
        else if (!other.CompareTag("Player")) // Falls kein Holzblock getroffen wird
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
