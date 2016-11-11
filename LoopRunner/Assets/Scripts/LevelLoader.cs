using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public Transform characterObjects;
    public Transform groundObjects;
    public Transform specialObjects;
    public Transform pickupObjects;

    public GameObject player_Prefab;

    public GameObject cardboard_Ground_0_Prefab;
    public GameObject cardboard_Ground_1_Prefab;

    public GameObject door_Prefab;
    public GameObject fan_Prefab;

    public GameObject key_Prefab;
    public GameObject gas_Prefab;
    public GameObject heavy_Prefab;
    public GameObject buoyancy_Prefab;

    public Texture2D texMap;

    public int levelWidth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel( string texMapName )
    {
        Color[] pixMap = texMap.GetPixels();

        int x = 0;
        int y = 0;

        foreach( Color pixel in pixMap )
        {
            if( pixel.Equals( new Color( 0f, 0f, 0f ) ) )
            {
                if( x % 2 == 0 )
                    Spawn( cardboard_Ground_0_Prefab, x, y, groundObjects );
                else 
                    Spawn( cardboard_Ground_1_Prefab, x, y, groundObjects );
            }
            else if( pixel.Equals( new Color( 0f, 0f, 1f ) ) )
            {
                Spawn( player_Prefab, x, y + 0.25f, characterObjects );
            }
            else if( pixel.Equals( new Color( 1f, 0f, 0f ) ) )
            {
                Spawn( door_Prefab, x, y, specialObjects );
            }
            else if( pixel.Equals( new Color( 1f, 0f, 1f/255f ) ) )
            {
                Spawn( fan_Prefab, x, y, specialObjects );
            }
            else if( pixel.Equals( new Color( 1f, 1f, 0f ) ) )
            {
                Spawn( key_Prefab, x, y, pickupObjects );
            }
            else if( pixel.Equals( new Color( 1f, 1f, 1f/255f ) ) )
            {
                Spawn( gas_Prefab, x, y, pickupObjects );
            }
            else if( pixel.Equals( new Color( 1f, 1f, 2f/255f ) ) )
            {
                Spawn( heavy_Prefab, x, y, pickupObjects );
            }
            else if( pixel.Equals( new Color( 1f, 1f, 3f/255f ) ) )
            {
                Spawn( buoyancy_Prefab, x, y, pickupObjects );
            }

            x++;
            if( x >= levelWidth )
            {
                x = 0;
                y++;
            }
        }
    }

    private void Spawn( GameObject obj, float x, float y, Transform container )
    {
                    Instantiate( obj, new Vector2( x, y ), Quaternion.Euler( Vector3.zero ), container );
    }
}
