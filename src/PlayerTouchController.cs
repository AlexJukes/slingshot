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
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ResetIsTouched() {
		isTouched = false;
	}

	void OnMouseDown() {
		mMouseDownPos = Input.mousePosition;
		mMouseDownPos.z = 0;
		Debug.Log("mMouseDownPos");
		Debug.Log(mMouseDownPos);
	}	

	void OnMouseDrag() {
   		Vector3 distance = Input.mousePosition - mMouseDownPos;
		playerController.RotateShipOnTouch(distance);
 	}

	void OnMouseUp() {
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
	if (other.tag == "Player") {
			return;
		}
    if (other.tag == "Planet") {
			return;
		}
	if (other.tag == "Activator") {
			return;
	}
 }
}
