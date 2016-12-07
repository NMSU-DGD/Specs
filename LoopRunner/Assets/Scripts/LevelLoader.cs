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

    public GameObject background_Prefab;

    public GameObject water_Prefab;
    //public GameObject water_Top;

    public GameObject door_Prefab;
    public GameObject fan_Prefab;
    public GameObject grate_Prefab;

    public GameObject key_Prefab;
    public GameObject gas_Prefab;
    public GameObject heavy_Prefab;
    public GameObject buoyancy_Prefab;

    public Texture2D texMap;

    public int levelWidth;

    [Header("Object Colors: ")]
    // Player
    public Color player = new Color(0f, 1f, 0f);

    // Environment
    public Color ground = new Color( 0f, 0f, 0f );
    public Color backGround = new Color( 127/255f, 127/255f, 127/255f );

    // Water
    public Color water = new Color( 0f, 0f, 127/255f );
    //public Color waterTop = new Color(0f,0f,254/255f)

    public Color waterKey = new Color( 1f, 255/255f, 127 / 255f);
    public Color waterGas = new Color( 1f, 254/255f, 127 / 255f);
    public Color waterHeavy = new Color( 1f, 253/255f, 127 / 255f);
    public Color waterBuoyant = new Color( 1f, 252/255f, 127 / 255f);

    public Color waterFan = new Color( 255/255f, 0f, 127 / 255f);
    public Color waterDoor = new Color(254/255f, 0f, 127 / 255f);
    public Color waterGrate = new Color(253/255f, 0f, 127 / 255f);

    public Color waterPlayer = new Color( 0f, 1f, 127 / 255f );

    // Pickups
    public Color key = new Color(1f, 255/255f, 0f);
    public Color gas = new Color(1f, 254/255f, 0f);
    public Color heavy = new Color(1f, 253/255f, 0f);
    public Color buoyant = new Color(1f, 252/255f, 0f);

    // Interactables
    public Color fan = new Color(255/255f, 0f, 0f);
    public Color door = new Color(254/255f, 0f, 0f);
    public Color grate = new Color(253/255f, 0f, 0f);

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
            if( pixel.Equals( ground ) )
            {
                if( x % 2 == 0 )
                    Spawn( cardboard_Ground_0_Prefab, x, y, groundObjects );
                else 
                    Spawn( cardboard_Ground_1_Prefab, x, y, groundObjects );
            }



            else if (pixel.Equals( backGround ))
            {
                Spawn(background_Prefab, x, y, groundObjects);
            }


            else if (pixel.Equals(water))
            {
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if ( pixel.Equals( player ) )
            {
                Spawn( player_Prefab, x, y + 0.25f, characterObjects );
            }
            else if (pixel.Equals( waterPlayer ))
            {
                Spawn(player_Prefab, x, y + 0.25f, characterObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if( pixel.Equals( door ) )
            {
                Spawn( door_Prefab, x, y, specialObjects );
            }
            else if (pixel.Equals(waterDoor))
            {
                Spawn(door_Prefab, x, y, specialObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if( pixel.Equals( fan) )
            {
                Spawn( fan_Prefab, x, y, specialObjects );
            }
            else if (pixel.Equals(waterFan))
            {
                Spawn(fan_Prefab, x, y, specialObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if (pixel.Equals(grate))
            {
                Spawn(grate_Prefab, x, y, specialObjects);
            }
            else if (pixel.Equals(waterGrate))
            {
                Spawn(grate_Prefab, x, y, specialObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if( pixel.Equals( key ) )
            {
                Spawn( key_Prefab, x, y, pickupObjects );
            }
            else if (pixel.Equals(waterKey))
            {
                Spawn(key_Prefab, x, y, pickupObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if( pixel.Equals( gas ) )
            {
                Spawn( gas_Prefab, x, y, pickupObjects );
            }
            else if (pixel.Equals(waterGas))
            {
                Spawn(gas_Prefab, x, y, pickupObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }


            else if( pixel.Equals( heavy ) )
            {
                Spawn( heavy_Prefab, x, y, pickupObjects );
            }
            else if (pixel.Equals(waterHeavy))
            {
                Spawn(heavy_Prefab, x, y, pickupObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            else if( pixel.Equals( buoyant ) )
            {
                Spawn( buoyancy_Prefab, x, y, pickupObjects );
            }
            else if (pixel.Equals(waterBuoyant))
            {
                Spawn(buoyancy_Prefab, x, y, pickupObjects);
                Spawn(water_Prefab, x, y, groundObjects);
            }



            x++;
            if( x >= levelWidth )
            {
                x = 0;
                y++;
            }


        }//end foreach
    }

    private void Spawn( GameObject obj, float x, float y, Transform container )
    {
        Instantiate( obj, new Vector2( x, y ), Quaternion.Euler( Vector3.zero ), container );
    }
}
