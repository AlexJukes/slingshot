using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour {

	public float DragEffect = 2;

	private bool inBounds;

	private bool visible = false;

	private int ResetDrag = 0;

	private int AppliedDrag;
	private Rigidbody playerRigidbody;

	private GameController gameController;

	private DebrisScript debrisScript;

	private Renderer debrisRenderer;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			inBounds = true;
		}
	}

	void Start() {
		playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();

		debrisRenderer = GetComponent<Renderer>();

			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		if(!visible) {
			debrisRenderer.enabled = false;
		}
	}

	void Update() {
		if(inBounds && visible) {
			playerRigidbody.drag = DragEffect;
		}

		if(gameController.activated) {
			visible = true;
		}

		if(visible){
			debrisRenderer.enabled = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			inBounds = false;
			playerRigidbody.drag = ResetDrag;
		}
	}
}
