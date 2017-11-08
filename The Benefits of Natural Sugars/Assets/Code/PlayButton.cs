using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public Button buttonplay;
    public Button buttonquit;
    // Use this for initialization
    void Start () {
        Button btnp = buttonplay.GetComponent<Button>();
        btnp.onClick.AddListener(buttonpclicky);

        Button btnq = buttonquit.GetComponent<Button>();
        btnp.onClick.AddListener(buttonqclicky);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void buttonpclicky()
    {
        SceneManager.LoadScene(1);
    }

    void buttonqclicky()
    {
        Application.Quit();
    }
}
