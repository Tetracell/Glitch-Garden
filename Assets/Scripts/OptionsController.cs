using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicManager; // if this is correct, it's because I named my musicmanager MuiscPlayer

    float volumeLevel;
    float currentVolume;
    float musicVolume;
    float difficulty;

    GameObject easyDiff;
    GameObject mediumDiff;
    GameObject hardDiff;

    //Text easyDiff;
    //Text mediumDiff;
    //Text hardDiff;

	// Use this for initialization
	void Start ()
    {
        // Testing the difficulty settings

        PlayerPrefsManager.SetDifficulty(0.5f);

        easyDiff = GameObject.Find("Easy");
        mediumDiff = GameObject.Find("Medium");
        hardDiff = GameObject.Find("Hard");

        easyDiff.SetActive(false);
        mediumDiff.SetActive(false);
        hardDiff.SetActive(false);

        //easyDiff = GameObject.Find("Easy").GetComponent<Text>();
        //mediumDiff = GameObject.Find("Medium").GetComponent<Text>();
        //hardDiff = GameObject.Find("Hard").GetComponent<Text>();
        if (PlayerPrefsManager.GetDifficulty() == 0f)
                {
                    easyDiff.SetActive(true);
                    //mediumDiff.SetActive(false);
                    //hardDiff.SetActive(false);
                }
                else if (PlayerPrefsManager.GetDifficulty() == 0.5f)
                {
                    //easyDiff.SetActive(false);
                    mediumDiff.SetActive(true);
                    //hardDiff.SetActive(false);
                }
                else if (PlayerPrefsManager.GetDifficulty() == 1.0f)
                {
                    //easyDiff.SetActive(false);
                    //mediumDiff.SetActive(false);
                    hardDiff.SetActive(true);
                }

        musicManager = GameObject.FindObjectOfType<MusicPlayer>(); // Find the music manager so I can access it.
        currentVolume = PlayerPrefsManager.GetMasterVolume(); // Get the saved value of the volume.
        volumeSlider.value = currentVolume;

        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        
        
        Debug.Log(musicManager);
        
	}

    public void setDefaults()
    {
        musicManager.audioSource.volume = 1.0f;
        volumeSlider.value = 1.0f;
        difficulty = 0.5f;
        difficultySlider.value = 0.5f;
        //volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }

	
	// Update is called once per frame
	void Update ()
    {
        musicManager.audioSource.volume = volumeSlider.value;
        volumeLevel = volumeSlider.value;
	}

    public void savePrefs()
    {
        PlayerPrefsManager.SetMasterVolume(volumeLevel);
    }



}
