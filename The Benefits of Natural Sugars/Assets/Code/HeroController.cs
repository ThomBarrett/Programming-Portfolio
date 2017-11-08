using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {
    Rigidbody2D rb;
    float MoveSpeed = 5;
    Vector3 vec;
    public int score;
    public float xpos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //The line below sets the xpos equal to playerx position so other objects can use it
        xpos = transform.position.x;

        //This chain of if statements handles the input from the players keyboard to detect the keys, "UP DOWN LEFT Right", Then maniplate the position based on a vector assoicated with the input given by the end user
        if (Input.GetKey("right"))
        {
            //Bellow is a example of how we maniplate the positon we make a vector x1 y0 z0
            vec = new Vector3(1, 0, 0);
            //We plus and assign the vec object times our pre assigned move speed and then time deltatime to keep it the speed constant
            transform.position += vec * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            vec = new Vector3(-1, 0, 0);
            transform.position += vec * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("up"))
        {
            vec = new Vector3(0, 1, 0);
            transform.position += vec * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            vec = new Vector3(0, -1, 0);
            transform.position += vec * MoveSpeed * Time.deltaTime;
        }
    }

    //This function bellow is for when this game object collides with another object with a box collider.
    private void OnCollisionEnter2D(Collision2D coll){
    
        //if the collision is with an enemy then the scene will restart respawning all the fruit and enemy
        if(coll.gameObject.tag == "ENEMY")
        {
            //Reloads current scene to start the player again
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        } 
    }


}
