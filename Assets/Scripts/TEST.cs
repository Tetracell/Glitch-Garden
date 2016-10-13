using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.SetMasterVolume(0f);
        // Resetting the default value for the volume, as the next setting sticks around.
        print(PlayerPrefsManager.GetMasterVolume());
        print("Setting the volueme to 0.3f");
        PlayerPrefsManager.SetMasterVolume(0.3f);
        print(PlayerPrefsManager.GetMasterVolume());
        print(PlayerPrefsManager.IsLevelUnlocked(2));        

        if (PlayerPrefsManager.IsLevelUnlocked(2))
        {
            print("Re-locking the level");
            PlayerPrefsManager.lockLevel(2);
            print(PlayerPrefsManager.IsLevelUnlocked(2));
        }
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(2));

        print(PlayerPrefsManager.GetDifficulty());
        
        print(PlayerPrefsManager.GetDifficulty());


    }

    // Fun fact: print is just an alias for debug.log in unity. 
    // Use this from now on. Leaving this here just as a reminder and
    // way to drill it into my head.
  
	// Update is called once per frame
	void Update () {
	
	}
}
