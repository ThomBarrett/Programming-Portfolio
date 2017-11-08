using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYController : MonoBehaviour
{
    GameInformation gi;
    HeroController hc;
    AudioControl ac;
    Vector3 vec = new Vector3();
    float MoveSpeed = 5;
    bool upFacing = true;
    // Use this for initialization
    void Start()
    {
        //We aquire access to the gameobject game information for use of this object
        GameObject gio = GameObject.Find("Gameinfo");
        //We use the script attached to this object 
        gi = gio.GetComponent<GameInformation>();
        //We add one to the virus total so we can count the viruses we have active in the game for added control
        gi.virusTotal += 1;

        //We aquire access to hero object
        GameObject hero = GameObject.Find("Hero");
        //We the aquire the hero object script
        hc = hero.GetComponent<HeroController>();
        vec = new Vector3(0, 1, 0);

        //We the aqquire the audio game object and then its script componet
        GameObject aco = GameObject.Find("AudioControl");
        ac = aco.GetComponent<AudioControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //We move the virus based on the vec vector
        transform.position += vec * MoveSpeed * Time.deltaTime;

        //We test the positionx of this instances to the player instance to see which way we should be facing
        if (transform.position.x < hc.transform.position.x)
        {
            Vector2 Scale = transform.localScale;
            Scale.x = 1.5f;
            transform.localScale = Scale;
        }
        else
        {
            Vector2 Scale = transform.localScale;
            Scale.x = -1.5f;
            transform.localScale = Scale;
        }

        //If all the fruit are eatten then the viruses will despawn randomly over a short time
        if (gi.fruitEaten == gi.fruitTotal)
        {

            int despawn = Random.Range(0, 6);
            //Destroy this gameobject after a specific elasped time
            Destroy(gameObject, despawn + Random.Range(0, 6));

        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //If we hit a wall we flip the direction of the virus so it will travel the other direction
        if (coll.gameObject.tag == "WALL")
        {
            if (upFacing == true)
            {
                upFacing = false;
                vec = new Vector3(0, -1, 0);
            }
            else
            {
                upFacing = true;

                vec = new Vector3(0, 1, 0);
            }
        }
    }

    private void OnDestroy()
    {
        //We add virus killed so we can manage wheather any exist as we cannot use the goal without killing them all
        gi.virusKilled += 1;
        //We check if the audiocontroller still exists to avoid nullrefernceexceptions
        if (ac != null)
        {
            //We call our audio function for the virus death 
            ac.EnemyKill();
        }
    }
}
