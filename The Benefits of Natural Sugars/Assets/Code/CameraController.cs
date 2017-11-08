using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject hero;

    private Vector3 campos;
	// Use this for initialization
	void Start () {
        campos = new Vector3(0, 0, -5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.position = hero.transform.position + campos;
    }
}
