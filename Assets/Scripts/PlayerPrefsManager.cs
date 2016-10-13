using UnityEngine;
using System.Collections;
using System; // <--- used for : throw new NotImplementedException();
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{


    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";


    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume < 1f) // made this >= 0f so that the volume could be set to 0.
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }    

    public static void UnlockLevel(int level)
    {   
        if(level <= SceneManager.sceneCountInBuildSettings - 1) 
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static void lockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 0); // use 1 for true
        }
        else
        {
            Debug.LogError("Trying to lock level not in build order");
        }
    }

    public static void SetDifficulty (int difficulty)
        {
            if (difficulty >= 1 && difficulty <= 3)
            {
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            }
            else
            {
                Debug.LogError("Difficulty set out of range");
            }
        }


    // Return methods

    public static bool IsLevelUnlocked (int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("This level is not unlocked");
            return false;            
        }
        //throw new NotImplementedException(); // this is cool. needs using System;
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static float GetMasterVolume()
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }

}
