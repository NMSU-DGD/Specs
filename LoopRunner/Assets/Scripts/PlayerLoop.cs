using UnityEngine;
using System.Collections;


public class PlayerLoop : MonoBehaviour {

    private float playerWidth;

    void Start () {
        playerWidth = GetComponent<BoxCollider2D>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if( transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + playerWidth/2 ) {
            Vector3 newPosition = transform.position;

            newPosition.x = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - playerWidth/4;

            transform.position = newPosition;
        } else if( transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - playerWidth/2 ) {
            Vector3 newPosition = transform.position;

            newPosition.x = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + playerWidth/4;

            transform.position = newPosition;
        }
	}
}
