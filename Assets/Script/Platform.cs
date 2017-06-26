using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float speedPlatform = 0.1f;

	Vector3 pos = new Vector3(0,-3.85f,-6);	
	// Update is called once per frame
	void Update () {
		float newPos = transform.position.x + (Input.GetAxis("Horizontal")*speedPlatform);
		pos = new Vector3(Mathf.Clamp(newPos,-3f,11f),-3.85f,-6);
		transform.position = pos;
	}
}
