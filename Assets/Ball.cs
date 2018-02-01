using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private float initialTouchTime;
	private float finalTouchTime;
	private Vector2 initialTouchPosition;
	private Vector2 finalTouchPosition;
	private float XaxisForce; //velocity on x;
	private float YaxisForce; //velocity on y;
	private float ZaxisForce; //velocity on z;
	private Vector3 RequireForce;
	private bool isBallThrown = false;

	void Start () {
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			OnTouchDown ();
		}
		if (Input.GetMouseButtonUp (0)) {
			OnTouchUp ();
			ThrowBall ();
		}
	}

	public void OnTouchUp(){
		initialTouchTime = Time.time;
		initialTouchPosition = Input.mousePosition;
	}
	public void OnTouchDown(){
		finalTouchTime = Time.time;
		finalTouchPosition = Input.mousePosition;
	}

	private void ThrowBall(){
		if (!isBallThrown) {
			XaxisForce = finalTouchPosition.x - initialTouchPosition.x;
			YaxisForce = finalTouchPosition.y - initialTouchPosition.y;
			ZaxisForce = finalTouchTime - initialTouchTime;

			RequireForce = new Vector3 (-XaxisForce, -YaxisForce*2, -ZaxisForce * 500);
			Debug.Log (RequireForce);
			GetComponent<Rigidbody> ().isKinematic = false;
			isBallThrown = true;
			GetComponent<Rigidbody> ().AddForce (RequireForce);
		}
	}
}

