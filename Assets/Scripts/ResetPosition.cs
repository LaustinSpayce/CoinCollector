using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	private Vector3 startingPosition;
	private Rigidbody thisRigidBody;

	void Awake () {
		startingPosition = this.transform.position;
		thisRigidBody = GetComponent<Rigidbody>();
	}
	
	public void ReturnToStartingPosition () {
		thisRigidBody.position = startingPosition;
	}
}
