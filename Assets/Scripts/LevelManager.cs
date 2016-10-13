using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    /* Todo:
     * Use the level manager to control the disabling of the fadein screen from the splash screen
     * Probably best to set the actual panel image as disabled by default, so that way I only
     * have to worry about it being enabled if coming from the splash screen. A haphazard attempt
     * at this code is already in the sceneFader script, though it should either be in this one, or 
     * at least called from here. */

	public float autoLoadNextLevelAfter;
    public static string lastLevelStr;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
	{
        if (autoLoadNextLevelAfter != 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
		
	}

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(name);
        isStartMenu();
    }

    public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

    public void isStartMenu()
    {
        Scene curLevel = SceneManager.GetActiveScene();
        if (curLevel.name == "01a Start Screen")
        {
            Debug.Log("I have found the start screen");
        }

    }


    void Update()
    {
        
    }
}




/* Scene curLevel = SceneManager.GetActiveScene();
        Debug.Log("Current scene: " + curLevel.name);
        GameObject startPanel = panel.gameObject;
        if (curLevel.name == "01a Start Screen")
        {
            if (sceneFader. == 0)
            {
                startPanel.SetActive(false);
            }
        }
        
*/
