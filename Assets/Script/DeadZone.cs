using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	/*void OnTriggerEnter(Collider col){
		GM.instance.LoseLife();
	}*/

	void OnCollisionEnter(Collision other){
		GM.instance.LoseLife();
	}
}
