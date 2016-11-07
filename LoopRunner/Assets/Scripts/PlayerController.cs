using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

	void Update () {
	    // Check for jump input
        if( Input.GetButtonDown( "Jump" ) )
        {
            playerMovement.Jump();
        }
	}
}
