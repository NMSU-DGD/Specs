using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private LevelLoader levelLoader;

	// Use this for initialization
	void Start () {
        levelLoader = GetComponent<LevelLoader>();

        levelLoader.LoadLevel( "Level1" );
	}
	
	// Update is called once per frame
	void Update () {
	}
}
