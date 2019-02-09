using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	GameObject playerObject;

	public Rigidbody rb;

	public float rotationSpeed = 10f;

	public float torque = 10f;

	public float turn  = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {

		//only apply rotation after launch
		if (!rb.isKinematic) {
			RotateShip();
		}
	}
	void RotateShip() { 
		rb.AddTorque(transform.up * torque * turn);
    }
}





