using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private LevelLoader levelLoader;

    public Texture2D texMapLevel;

    public string currentLevel;

    public string nextLevel;

    void Awake()
    {
        if( instance == null )
        {
            instance = this;

            levelLoader = GetComponent<LevelLoader>();
        }
    }

	// Use this for initialization
	void Start ()
    {
        levelLoader.LoadLevel( texMapLevel );
	}
        
    public void RestartLevel()
    {
        SceneManager.LoadScene( currentLevel );
    }

    public void NextLevel()
    {
        SceneManager.LoadScene( nextLevel );
    }
}
