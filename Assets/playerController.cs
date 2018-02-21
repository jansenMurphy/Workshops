using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public Vector3 playerInput = Vector3.zero;
	public int jumpstate = 0;// 0 is nothing 1 is down 2 is held 3 is up

	void Update () {
		playerInput.x = Input.GetAxisRaw ("Horizontal");
		playerInput.z = Input.GetAxisRaw ("Vertical");

		if (Input.GetButtonDown ("Jump")) {
			jumpstate = 1;
		} else if (Input.GetButtonUp ("Jump")) {
			jumpstate = 3;
		} else if (Input.GetButton ("Jump") && jumpstate != 1) {
			jumpstate = 2;
		} else if (jumpstate != 1){
			jumpstate = 0;
		}
				
	}
}
