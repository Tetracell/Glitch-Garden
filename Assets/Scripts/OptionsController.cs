using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicManager; 
    // if this is correct, it's because I named my musicmanager MuiscPlayer

    float volumeLevel;
    float currentVolume;
    float musicVolume;
    float difficulty;

    GameObject easyDiff;
    GameObject mediumDiff;
    GameObject hardDiff;
  
	// Use this for initialization
	void Start ()
    {
        // Testing the difficulty settings
        //PlayerPrefsManager.SetDifficulty(0.1f);

        #region Inital values for difficulty objects
        easyDiff = GameObject.Find("Easy");
        mediumDiff = GameObject.Find("Medium");
        hardDiff = GameObject.Find("Hard");

        easyDiff.SetActive(false);
        mediumDiff.SetActive(false);
        hardDiff.SetActive(false);
        #endregion

        musicManager = GameObject.FindObjectOfType<MusicPlayer>(); // Find the music manager so I can access it.
        currentVolume = PlayerPrefsManager.GetMasterVolume(); // Get the saved value of the volume.
        volumeSlider.value = currentVolume;

        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        
        
        Debug.Log(musicManager);
        
	}

	// Update is called once per frame
	void Update ()
    {
        musicManager.ChangeVolume(volumeSlider.value);
        volumeLevel = volumeSlider.value;

        if (difficultySlider.value >= 0f && difficultySlider.value < 0.5f)
        {
            easyDiff.SetActive(true);
            mediumDiff.SetActive(false);
            hardDiff.SetActive(false);
        }
        else if (difficultySlider.value >= 0.5f && difficultySlider.value < 0.85f)
        {
            easyDiff.SetActive(false);
            mediumDiff.SetActive(true);
            hardDiff.SetActive(false);
        }
        else if (difficultySlider.value >= 0.85f)
        {
            easyDiff.SetActive(false);
            mediumDiff.SetActive(false);
            hardDiff.SetActive(true);
        }


    }

    public void savePrefs()
    {
        PlayerPrefsManager.SetMasterVolume(volumeLevel);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
    }

    public void setDefaults()
        {
            musicManager.ChangeVolume(0.7f);
            volumeSlider.value = 0.7f;
            difficulty = 0.5f;
            difficultySlider.value = difficulty;
            //volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        }


}
