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
    int difficulty;

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
        volumeLevel = PlayerPrefsManager.GetMasterVolume(); // Get the saved value of the volume.
        volumeSlider.value = volumeLevel;

        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        
        
        Debug.Log(musicManager);
        
	}

	// Update is called once per frame
	void Update ()
    {
        volumeLevel = volumeSlider.value;
        musicManager.ChangeVolume(volumeLevel);        

        #region If statement for changing difficulty text
        if (difficultySlider.value == 1)
        {
            easyDiff.SetActive(true);
            mediumDiff.SetActive(false);
            hardDiff.SetActive(false);
        }
        else if (difficultySlider.value == 2)
        {
            easyDiff.SetActive(false);
            mediumDiff.SetActive(true);
            hardDiff.SetActive(false);
        }
        else if (difficultySlider.value == 3)
        {
            easyDiff.SetActive(false);
            mediumDiff.SetActive(false);
            hardDiff.SetActive(true);
        }
        #endregion
    }

    public void savePrefs()
    {
        PlayerPrefsManager.SetMasterVolume(volumeLevel);
        PlayerPrefsManager.SetDifficulty((int)difficultySlider.value); // Slider values are apparently always a float, so a cast is used to convert properly.
    }

    public void setDefaults()
        {
            musicManager.ChangeVolume(0.7f);
            difficulty = 2;
            volumeSlider.value = musicManager.audioSource.volume;
            difficultySlider.value = difficulty;
            

            //difficultySlider.value = PlayerPrefsManager.GetDifficulty();    // Seems like I need to change the value of the sliders manually                                     
            //volumeSlider.value = PlayerPrefsManager.GetMasterVolume();      // to stop things from messing up. Ben doesn't though in the video?
        }


}
