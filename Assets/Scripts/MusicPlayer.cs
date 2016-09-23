using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	//static MusicPlayer instance = null;

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + name);        
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		Debug.Log("Hitting the start function");
		if (SceneManager.GetActiveScene().buildIndex == 0) // Used to play music on the loading screen. This is necessary, try to find better way.
		{
			audioSource.clip = levelMusicChangeArray[0];
			audioSource.Play();
		}
	}

	void OnLevelWasLoaded (int level)
	{
		AudioClip currentLevel = levelMusicChangeArray[level];
		Debug.Log("Playing clip: " + levelMusicChangeArray[level]);
		Debug.Log("Current level: " + level);

		if (currentLevel) // Checking if there is some music attatched to the current scene
		{
			audioSource.clip = currentLevel;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
