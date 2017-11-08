using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXController : MonoBehaviour {
    GameInformation gi;
    AudioControl ac;



    Vector3 vec = new Vector3();
    float MoveSpeed = 5;
    bool rightFacing = true;
    // Use this for initialization
    
	void Start () {
        //We aquire access to the gameobject game information for use of this object
        GameObject gio = GameObject.Find("Gameinfo");
        //We use the script attached to this object 
        gi = gio.GetComponent<GameInformation>();
        //We the aqquire the audio game object and then its script componet
        GameObject aco = GameObject.Find("AudioControl");
        ac = aco.GetComponent<AudioControl>();

        //We add one to the virus total so we can count the viruses we have active in the game for added control
        gi.virusTotal += 1;
        

        //We set default start direction vector
        vec = new Vector3(1, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        //We plus and assign the vec times our movespeed and deltatime
        transform.position += vec * MoveSpeed * Time.deltaTime;
        //We test to see if all the fruit have been eatten if they have we destroy the game object
        if (gi.fruitEaten == gi.fruitTotal)
        {
            //We randomly generate despawn time
            int despawn = Random.Range(0, 6);
            
            //We destroy after elapsed time peroid
            Destroy(gameObject, despawn + Random.Range(0, 6));

        }
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //On collision with wall we change the way the virus faces and change the direction it moves
        if(coll.gameObject.tag == "WALL")
        {
            if(rightFacing == true)
            {
                rightFacing = false;
                Vector2 Scale = transform.localScale;
                Scale.x = -1.7f;
                transform.localScale = Scale;
                vec = new Vector3(-1, 0, 0);
            }
            else
            {
                rightFacing = true;
                Vector2 Scale = transform.localScale;
                Scale.x = 1.7f;
                transform.localScale = Scale;
                vec = new Vector3(1, 0, 0);
            }
        }
    }

    
    private void OnDestroy()
    {
        //When virus is destroyed we plus one to our virus killed game info
        gi.virusKilled += 1;
        //We call the audio for the death if it still exists to avoid nullreferanceexceptions
        if (ac != null)
        {
            //We call our audio function
            ac.EnemyKill();
        }
        
    }
}
