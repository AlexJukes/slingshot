using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	GameObject playerObject;

	public Rigidbody rb;

	public float rotationSpeed = 2;

	Vector3 direction;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		RotateShip();
	}
	void RotateShip() { 
		direction = rb.transform.forward;
		direction.z = 0;
		rb.transform.forward =
			Vector3.Slerp(
				direction, 
				rb.velocity.normalized, 
				Time.deltaTime
			);
	}
}





