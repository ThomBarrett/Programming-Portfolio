using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour {

    public GameObject GoalRejection;

    GameInformation gi;
    
	// Use this for initialization
	void Start () {
        GameObject gio = GameObject.Find("Gameinfo");
        gi = gio.GetComponent<GameInformation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HERO")
        {
            if(gi.fruitEaten == gi.fruitTotal)
            {
                if(gi.virusKilled == gi.virusTotal)
                {
                    int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

                    SceneManager.LoadScene(nextScene);
                }
            }
            else
            {
                GoalRejection.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HERO")
        {
            GoalRejection.SetActive(false);
        }
    }
}
