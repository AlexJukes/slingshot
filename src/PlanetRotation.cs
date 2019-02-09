using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

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
		RotatePlanet();
	}
	void RotatePlanet() { 
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
}
