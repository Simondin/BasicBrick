using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float initialSpeed = 600f;
	private Rigidbody[] rb;
	private bool play;

	// Use this for initialization
	void Awake () {
		rb = GetComponents<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && !this.play) {
			transform.parent = null;
			this.play = true;
			rb[0].isKinematic = false;
			rb[0].AddForce (new Vector3 (this.initialSpeed, this.initialSpeed, 0));
		}
	}
}
