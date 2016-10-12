using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneFader : MonoBehaviour {

    public float fadetime = 2.5f;
    Color panelAlpha = Color.black; // Changed to fadein from black, seems nicer.
    Image fadePanel;
    Image fadePanelStart;
    public GameObject fadeOut;
    bool splashFirst;

    void OnSceneChange()
    {
        
    }

    // Use this for initialization

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    void Start () {
        fadePanel = GameObject.Find("Fade Curtain").GetComponent<Image>();
        splashFirst = true;
        
	}

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("I have loaded a new level!");
        Debug.Log("The level that I have loaded is: " + level);
        fadePanelStart = GameObject.Find("Fade CurtainStart").GetComponent<Image>(); // Gets the fade panel on scene change. DURRR
        Debug.Log("The panel I am looking at: " + fadePanelStart.name);
        
        //fadePanel.enabled = true;
        //fadePanel = GameObject.Find("Fade Curtain").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (splashFirst)
        {
            splashLoader();
        }
        else
        {
            startLoader();
        }
	}

    void splashLoader()
    {
        panelAlpha.a -= (1.0f / fadetime) * Time.deltaTime;
        fadePanel.color = panelAlpha;
        if (fadePanel.color.a <= 0)
        {
            splashFirst = false;
            Debug.Log("I have completed fading out the splash panel");
        }
    }

    void startLoader()
    {
        panelAlpha.a -= (1.0f / fadetime) * Time.deltaTime;
        fadePanelStart.color = panelAlpha;
        if (fadePanelStart.color.a <= 0)
        {
            fadePanelStart.enabled = false; // Disables the panel. Could also destroy it? What the fuck does it matter?
            //Destroy(fadePanel);
        }
    }
}

