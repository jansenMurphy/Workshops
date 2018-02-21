using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour {

	protected Rigidbody rb;
	protected playerManager pm;
	public float groundSpeed = 2f, skySpeed =.1f, jumpHeight = 10, jetpackVelocity = 2, gravity = 3;
	protected LayerMask lm;


	Vector3 moveTo = Vector3.zero;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
		lm = LayerMask.GetMask ("Default");
		pm = GetComponent<playerManager> ();
	}

	void FixedUpdate () {
		mov ();
	}

	protected virtual void mov(){
		moveTo = pm.pc.playerInput;
		moveTo = moveTo.normalized;
		bool groundTrue = isGrounded();
		if (groundTrue) {
			moveTo *= groundSpeed;
			moveTo.y = 0;
		} else {
			moveTo *= skySpeed;
			moveTo.y = gravity;
		}
		switch (pm.pc.jumpstate) {
		case 1:
			if (!groundTrue)
				break;
			moveTo.y += jumpHeight;
			pm.pc.jumpstate = 2;
			break;
		case 2:
			moveTo.y += jetpackVelocity;
			break;
		case 3:
			;
			break;
		}
		if (groundTrue && (pm.pc.jumpstate == 0 || pm.pc.jumpstate == 3)) {
			rb.MovePosition (gameObject.transform.position + gameObject.transform.TransformDirection(moveTo));
		}else{
			rb.AddForce (gameObject.transform.TransformDirection(moveTo));
		}
	}

	virtual protected bool isGrounded(){
		RaycastHit rayHit;

		Physics.SphereCast (gameObject.transform.position, .5f, -gameObject.transform.up, out rayHit, 1f, lm);
		if (rayHit.collider)
			return true;
		return false;
	}

}
