using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerLoop : MonoBehaviour {

    private float playerWidth;

    void Start () {
        playerWidth = GetComponent<BoxCollider2D>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if( transform.position.x > Camera.main.orthographicSize * Camera.main.aspect + playerWidth/2f ) {
            Vector3 newPosition = transform.position;

            newPosition.x = -Camera.main.orthographicSize * Camera.main.aspect;

            transform.position = newPosition;
        } else if( transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect - playerWidth/2f ) {
            Vector3 newPosition = transform.position;

            newPosition.x = Camera.main.orthographicSize * Camera.main.aspect;

            transform.position = newPosition;
        }
	}
}
