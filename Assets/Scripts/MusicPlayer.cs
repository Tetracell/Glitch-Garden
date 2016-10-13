using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	//static MusicPlayer instance = null;

	public AudioClip[] levelMusicChangeArray;
	public AudioSource audioSource;



    //To do:
    
    //  1) Have the music manager recognize that a clip is already playing and handle it better.
    //      I don't want the music to restart simply because I'm going back from the options screen
    //      to the start menu. A minor problem, but annoying.



    void Awake()
	{
		DontDestroyOnLoad(gameObject);        
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		if (SceneManager.GetActiveScene().buildIndex == 0) // Used to play music on the loading screen. This is necessary, try to find better way.
		{
			audioSource.clip = levelMusicChangeArray[0];
			audioSource.Play();
		}
	}

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

	void OnLevelWasLoaded (int level)
	{
		AudioClip currentLevel = levelMusicChangeArray[level];
        if (currentLevel) // Checking if there is some music attatched to the current scene
		{
                audioSource.clip = currentLevel;
                audioSource.loop = true;
                audioSource.Play();
        }
	}
}
