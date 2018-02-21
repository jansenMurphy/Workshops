using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

	public playerController pc;
	public playerMotor pmotor;

	void Awake(){
		if (pc == null) {
			pc = gameObject.GetComponent<playerController> ();
		}
		if (pmotor == null) {
			pmotor = gameObject.GetComponent<playerMotor> ();
		}
	}
}
