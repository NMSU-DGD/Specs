using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private SpriteRenderer sr;

    private PlayerMovement playerMovement;
    private bool hasKey = false;

    public enum PlayerStatus { HEAVY,GAS,BUOYANT };

    public PlayerStatus currentStatus = PlayerStatus.HEAVY;

    public PlayerStatus getCurrentStatus() { return currentStatus; }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        sr.color = new Color( 0.8f, 0.8f, 0.5f, 1.0f );
    }

	void Update () {
	    // Check for jump input
        if( Input.GetButtonDown( "Jump" ) )
        {
            playerMovement.Jump();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasKey = true;
        }

        if(other.gameObject.CompareTag("Door"))
        {
            if(!hasKey)
            {
                //this kills the player
                Die();
            }
            //otherwise kill the door
            else other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Grate"))
        {
            if ( currentStatus != PlayerStatus.GAS)
            {
                //this kills the player
                Die();
            }
        }

        if (other.gameObject.CompareTag("Water"))
        {
            if (currentStatus == PlayerStatus.GAS)
            {
                //this kills the player
                Die();
            }
        }

        if (other.gameObject.CompareTag("Gas"))
        {
            currentStatus = PlayerStatus.GAS;
            sr.color = new Color( 0f, 1f, 0f, 0.5f );
        }

        if (other.gameObject.CompareTag("Heavy"))
        {
            currentStatus = PlayerStatus.HEAVY;
            sr.color = new Color( 0.8f, 0.8f, 0.5f, 1.0f );

        }

        if(other.gameObject.CompareTag("Buoyant"))
        {
            currentStatus = PlayerStatus.BUOYANT;
            sr.color = new Color(0.6f, 0.6f, 1f, 1f);
        }


        if (other.gameObject.CompareTag("Goal"))
        {
            Win();
        }

    }

    private void Win()
    {
        GameManager.instance.NextLevel();
    }

    private void Die()
    {
        GameManager.instance.RestartLevel();
    }
}