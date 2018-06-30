using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchController : MonoBehaviour {

	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;

	Vector3 mDirection;

	private bool isTouched;

	PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponentInParent<PlayerController>();
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		isTouched = false;
		Debug.Log("started");
		// Debug.Log("isTouched");
		// Debug.Log(isTouched.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ResetIsTouched() {
		isTouched = false;
	}

	void OnMouseDown() {
		Debug.Log("mMouseDown");
		mMouseDownPos = Input.mousePosition;
		mMouseDownPos.z = 0;
		Debug.Log("mMouseDownPos");
		Debug.Log(mMouseDownPos);
	}	

	void OnMouseDrag() {
		Debug.Log("OnMouseDrag");
   		Vector3 distance = Input.mousePosition - mMouseDownPos;
		playerController.RotateShipOnTouch(distance);
 	}

	void OnMouseUp() {
		Debug.Log("OnMouseUp");
		if (isTouched) return;
		isTouched = true;
		mMouseUpPos = Input.mousePosition;
		mMouseUpPos.z = 0;
		mDirection = mMouseDownPos - mMouseUpPos;
		playerController.LaunchPlayer(mDirection);
	}

	// override trigger events for the touch collider
	 void OnTriggerEnter(Collider other)
 {
	Debug.Log("OnTriggerEnter");
	Debug.Log(other.ToString());
	
	 
	if (other.tag == "Player") {
	Debug.Log("Player");
		
			return;
		}
    if (other.tag == "Planet") {
	Debug.Log("Planet");
		
			return;
		}
	if (other.tag == "Activator") {
	Debug.Log("Activator");
		
			return;
	}
 }
}
