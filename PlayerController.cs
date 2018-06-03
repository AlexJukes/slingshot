using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;

	Vector3 mStartPosition;
	GameObject playerObject;

	GameController gameController;
	PlayerTouchController playerTouchController;


	public Rigidbody rb;

	public float spinSpeed = 35;

	float rotationSpeed = 2;

	public float speed = .1f;
	private const float gravitationalConstant = 6.672e-11f;

	private bool isTouched;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		playerTouchController = GetComponentInChildren<PlayerTouchController>();
		if (playerTouchController == null)
		{
			Debug.Log ("Cannot find 'PlayerTouchController' script");
		}
		
		playerTouchController = GetComponentInChildren<PlayerTouchController>();
		if (playerTouchController == null)
		{
			Debug.Log ("Cannot find 'PlayerTouchController' script");
		}

		// Prevent gravity affecting object before player start
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = true;

	}

	void Update () {
		if (!rb.isKinematic) {
		  transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
		}
	}

	public void LaunchPlayer(Vector3 direction) {
		rb.isKinematic = false;
		rb.AddForce (direction * speed, ForceMode.Impulse);
	}

	public void RotateShipOnTouch(Vector3 direction) { 
		float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;
		if (direction != Vector3.zero) {
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		Transform pivot = transform.parent; // use an empty parent gameObject to act as a pivot point
		pivot.rotation =  Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
		}
	}

	void ResetPosition() {
		gameObject.transform.position = mStartPosition;
		rb.isKinematic = true;
		playerTouchController.ResetIsTouched();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Planet") {
			Destroy(gameObject);	
			gameController.GameOver ();
		}
		
		if (other.tag == "Activator") {
			gameController.ActivateDebris();
			this.ResetPosition ();
		}
		if (other.tag == "TouchController") {
			return;
		}
	}
}
