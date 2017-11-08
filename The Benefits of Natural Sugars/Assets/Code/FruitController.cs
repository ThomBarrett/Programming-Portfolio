using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    /*I want this object to be able to access the game info hero information for better interations with the player.
     *Also the audiocontroller so we can set audio to play apon certain events like when a player eats a fruit.*/
    HeroController hc;
    GameInformation gi;
    AudioControl ac;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //We aquire access to the Gameinfo Gameobject
        GameObject gio = GameObject.Find("Gameinfo");
        //We take the GameInformation Script from the object and assing it too gi
        gi = gio.GetComponent<GameInformation>();
        
        //Every fruit instance of any type will be recorded in game informaiton for use else where such as UI and enemy information
        gi.fruitTotal += 1;

        //We let this object aquire access to the AudioControl
        GameObject aco = GameObject.Find("AudioControl");
        //Then we use the object to get access to the script attached to it
        ac = aco.GetComponent<AudioControl>();

        //Access to the hero object and the get access the script attached to the hero
        GameObject hero = GameObject.Find("Hero");
        hc = hero.GetComponent<HeroController>();

        //if(gameObject.tag == "PEAR")
        //{
        //    int rand = Random.Range(0, 360);
        //    transform.Rotate(0, 0, rand);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //We want this code to react different depending on the kind of fruit instance this is
        //Bellow we check if the instance is an apple
        if (gameObject.tag == "APPLE")
        {
            //We want the apple to alway face the direction of the player on the x axis
            if (transform.position.x < hc.transform.position.x)
            {
                //We create a vector called scale and we use this to flip the sprite side to side based on the xpos varible of the player
                Vector2 Scale = transform.localScale;
                Scale.x = 1.5f;
                //We assign the localscale of the instance to the new scale vector we just created
                transform.localScale = Scale;
            }
            else
            {
                Vector2 Scale = transform.localScale;
                Scale.x = -1.5f;
                transform.localScale = Scale;
            }

        }
        //Here we check if the instance is a pear
        if (gameObject.tag == "PEAR")
        {
            //We create a new random interger from -1 to 2
            int rand = Random.Range(-1, 2);
            //We effect the Z rotation based on the random interger we just created
            transform.Rotate(0, 0, rand);

        }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //If you collide with a player we destroy the instance of the object
        if (coll.gameObject.tag == "HERO")
        {
            //We minus a fruit from the game information fruitEaten varible so we can keep track of the players progress in regards to how the eat the fruit
            gi.fruitEaten += 1;
            //Then we destroy the gameObject so it no longer effects the game
            Destroy(gameObject);
        }
    }

    //When we destroy the instance we want to play a sound that suggests the player has eatten the fruit so we call our a audio controll with a function we wrote for the playing for fruit sounds
    private void OnDestroy()
    {
        //If ac object is null we don't call it's function to avoid an nullrefernceexception
        if (ac != null)
        {
            ac.FruitEat();
        }
            
    }
}
