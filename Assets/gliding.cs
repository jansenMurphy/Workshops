using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gliding : playerMotor {

	public float rotateSpeed = 5;

	override protected void mov(){
		gameObject.transform.Rotate (Vector3.up*rotateSpeed*pm.pc.playerInput.x);
		rb.MovePosition (rb.position + rb.transform.forward * skySpeed - rb.transform.up * gravity);
	}
}
