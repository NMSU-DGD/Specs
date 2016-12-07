using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField] public LayerMask groundMask; // Used to check if the player is on the ground

    [SerializeField] private float runSpeed;     // Player's constant run speed
    [SerializeField] private float jumpStrength; // Player's jump strength

    public float velocityCap;
    public float fanAcceleration;
    public float waterAcceleration;

    void Start()
    {
        // Set component references
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
            1f,
            groundMask
        );

        // Jump if player is on the ground
        if( _grounded )
        {
            //if(GetComponent<PlayerController>().getCurrentStatus()!=PlayerController.playerStatus.HEAVY)
                rb2D.AddForce( new Vector2( 0f, jumpStrength ) );
            //else
            //    rb2D.AddForce(new Vector2(0f, jumpStrength/1.25f));
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fan"))
        {
            if(GetComponent<PlayerController>().getCurrentStatus()==PlayerController.PlayerStatus.GAS)
                if(rb2D.velocity.y<=velocityCap)rb2D.AddForce(new Vector2(0f, fanAcceleration));
        }
        if (other.gameObject.CompareTag("Water"))
        {
            if (GetComponent<PlayerController>().getCurrentStatus() == PlayerController.PlayerStatus.BUOYANT)
                if (rb2D.velocity.y <= velocityCap) rb2D.AddForce(new Vector2(0f, waterAcceleration));
        }
    }
}
