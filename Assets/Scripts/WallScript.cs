using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {   
    GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((ball.transform.position.x - transform.position.x) > 60) {
            Destroy(this.gameObject);
        }
		
	}
}
