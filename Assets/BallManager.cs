using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	public GameObject ball;
	private GameObject actualBall;
	private List<GameObject> balls = new List<GameObject>();

	// Use this for initialization
	void Start () {
		actualBall = CreateNewBall();	
	}
	
	// Update is called once per frame
	void Update () {
		if(!actualBall.GetComponent<Rigidbody>().isKinematic){
			actualBall = CreateNewBall ();
		}
	}

	GameObject CreateNewBall(){
		return (GameObject)Instantiate (ball);
	}
}
