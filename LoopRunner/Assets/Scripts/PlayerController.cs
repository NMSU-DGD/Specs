using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private SpriteRenderer sr;

    private PlayerMovement playerMovement;
    private bool hasKey = false;
    public string nextScene;

    public enum playerStatus { HEAVY,GAS,BUOYANT };

    public playerStatus currentStatus = playerStatus.HEAVY;

    public playerStatus getCurrentStatus() { return currentStatus; }

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
                SceneManager.LoadScene(nextScene);
            }
            //otherwise kill the door
            else other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Grate"))
        {
            if ( currentStatus != playerStatus.GAS)
            {
                //this kills the player
                SceneManager.LoadScene(nextScene);
            }
        }

        if (other.gameObject.CompareTag("Gas"))
        {
            currentStatus = playerStatus.GAS;
            sr.color = new Color( 0f, 1f, 0f, 0.5f );
        }

        if (other.gameObject.CompareTag("Heavy"))
        {
            currentStatus = playerStatus.HEAVY;
            sr.color = new Color( 0.8f, 0.8f, 0.5f, 1.0f );

        }

    }

    
}