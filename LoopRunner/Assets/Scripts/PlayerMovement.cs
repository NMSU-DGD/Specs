using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D col2D;
    private Rigidbody2D rb2D;

    [SerializeField] public LayerMask groundMask; // Used to check if the player is on the ground

    [SerializeField] private float runSpeed;     // Player's constant run speed
    [SerializeField] private float jumpStrength; // Player's jump strength

    void Start()
    {
        // Set component references
        col2D = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateRunning();
    }

    private void UpdateRunning()
    {
        // Store current velocity and update running velocity
        Vector2 vel;
        vel = rb2D.velocity;
        vel.x = runSpeed;

        // Set player rigidbody velocity
        rb2D.velocity = vel;
    }

    public void Jump()
    {
        // Check if player is on the ground
        RaycastHit2D _grounded = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            col2D.bounds.size.y / 2f + 0.05f,
            groundMask
        );

        // Jump if player is on the ground
        if( _grounded )
        {
            rb2D.AddForce( new Vector2( 0f, jumpStrength ) );
        }
    }
}
