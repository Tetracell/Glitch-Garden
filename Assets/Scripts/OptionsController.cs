using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicManager; // if this is correct, it's because I named my musicmanager MuiscPlayer

    float volumeLevel;

	// Use this for initialization
	void Start ()
    {
        volumeLevel = PlayerPrefsManager.GetMasterVolume(); // Get the saved value of the volume
        volumeSlider.value = volumeLevel; // Set the slider to the value above so that it doesn't get fucked up
        musicManager = GameObject.FindObjectOfType<MusicPlayer>();
        Debug.Log(musicManager);
        
	}


	
	// Update is called once per frame
	void Update ()
    {
        musicManager.audioSource.volume = volumeSlider.value;
        volumeLevel = musicManager.audioSource.volume;
	}

    public void savePrefs()
    {
        PlayerPrefsManager.SetMasterVolume(volumeLevel);
    }



}
