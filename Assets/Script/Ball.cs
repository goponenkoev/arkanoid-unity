using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballVelocity = 600f;

	private Rigidbody rb;
	private bool isPlay;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && isPlay == false){
			transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
			rb.AddForce (new Vector3(ballVelocity, ballVelocity, 0));
		}
	}
}
