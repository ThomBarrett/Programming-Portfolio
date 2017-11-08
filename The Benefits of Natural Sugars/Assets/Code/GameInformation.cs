using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInformation : MonoBehaviour {
    public int fruitTotal = 0;
    public int fruitEaten = 0;
    public int virusTotal = 0;
    public int virusKilled = 0;
    
    public GameObject FruitEatenText;
    Text fruitTxt;

    public GameObject EnemiesKilledText;
    Text VirusTxt;

    // Use this for initialization
    void Start () {
        fruitTxt = FruitEatenText.GetComponent<Text>();
        fruitTxt.text = "Fruits Eaten: ";
        fruitTxt.text += fruitEaten;
        fruitTxt.text += "/";
        fruitTxt.text += fruitTotal;

        VirusTxt = EnemiesKilledText.GetComponent<Text>();
        VirusTxt.text = "Viruses Killed: ";
        VirusTxt.text += virusKilled;
        VirusTxt.text += "/";
        VirusTxt.text += virusTotal;

    }
	
	// Update is called once per frame
	void Update () {
        fruitTxt.text = "Fruits Eaten: ";
        fruitTxt.text += fruitEaten;
        fruitTxt.text += "/";
        fruitTxt.text += fruitTotal;

        VirusTxt.text = "Viruses Killed: ";
        VirusTxt.text += virusKilled;
        VirusTxt.text += "/";
        VirusTxt.text += virusTotal;


    }
}
