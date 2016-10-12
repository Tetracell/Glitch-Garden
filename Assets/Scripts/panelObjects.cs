using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class panelObjects: MonoBehaviour {

    public Image fadePanel;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();
    }

    void OnLevelWasLoaded(int level)
    {
        fadePanel = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
