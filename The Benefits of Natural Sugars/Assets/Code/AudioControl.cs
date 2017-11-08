using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {
    public AudioSource audio;
    public AudioClip EatFruit;
    public AudioClip VirusKill;
	// Use this for initialization
	void Start () {
		
	}


    // Update is called once per frame
    void Update () {
		
	}

    //This function is called on virus deaths
    public void EnemyKill()
    {
        //We get the audio source componet
        audio = GetComponent<AudioSource>();
        //Change the audioclip to the Virus kill sound
        audio.clip = VirusKill;
        //Then we play the current audioclip
        audio.Play();
    }

    //This function is called when the player eats a fruit
    public void FruitEat() {
        //We get the audio source componet
        audio = GetComponent<AudioSource>();
        //Change the audioclip to the Virus kill sound
        audio.clip = EatFruit;
        //Then we play the current audioclip
        audio.Play();
    }
}
