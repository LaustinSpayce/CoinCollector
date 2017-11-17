using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	public float animationTime = 2.0f;
	public float hiddenTime = 5.0f;
	public float shakeTime = 3.0f;
	public float minimumDelay = 5.0f;
	public float maxDelay = 10.0f;

	public float distanceDown = 2.0f;
	public float shakeDistance = 0.05f;
	public float shakeSpeed = 50f;

	public GameObject[] blockPattern;

	private bool isMoving = false;
	private Rigidbody blockRigidBody;
	private Vector3 initialTransform;
	private float animationSpeed;
	private float timeSinceLastMovement;
	private float currentDelay;
	private Vector3 startingPosition;

	void Start () {
		BreakParents();
		initialTransform = (this.transform.position);
		startingPosition = this.transform.position;
		blockRigidBody = GetComponent<Rigidbody>();
		animationSpeed = distanceDown / animationTime;
		timeSinceLastMovement = 0.0f;
		WhatIsTheDelay();
	}
	
	void FixedUpdate () {
		if (isMoving == true) {
			return;
		}
		timeSinceLastMovement += Time.deltaTime;
		if (timeSinceLastMovement >= currentDelay) {
			isMoving = true;
			StartCoroutine(BlocksMovePattern());
		}
	}

	private void MakeParents() {
		for (int i = 0; i < blockPattern.Length; i++) {
			blockPattern[i].transform.SetParent(this.transform, true);
		}

	}

	private void BreakParents() {
		for (int i = 0; i < blockPattern.Length; i++) {
			blockPattern[i].transform.SetParent(null);
			var reset = blockPattern[i].GetComponent<ResetPosition>();
			reset.ReturnToStartingPosition();
		}
	}

	private void WhatIsTheDelay() {
		currentDelay = Random.Range(minimumDelay, maxDelay);
	}

	private IEnumerator BlocksMovePattern () {
		isMoving = true;
		MakeParents();
		// yield return StartCoroutine (BlocksShake());
		// Debug.Log(startingPosition);
		yield return StartCoroutine (BlocksDrop());
		// Debug.Log(startingPosition);
		yield return StartCoroutine (BlocksHold());
		// Debug.Log(startingPosition);
		yield return StartCoroutine (BlocksReturn());
		// Debug.Log(startingPosition);
		BreakParents();
		timeSinceLastMovement = 0.0f;
		WhatIsTheDelay();
		isMoving = false;
	}

	// private IEnumerator BlocksShake() {
	// 	float timeElapsed = 0f;
	// 	while (timeElapsed <= shakeTime) {
	// 		var targetPosition = new Vector3 (initialTransform.x + Mathf.Sin(shakeDistance * Time.time * shakeSpeed),
	// 			initialTransform.y,
	// 			initialTransform.z + shakeDistance * Mathf.Sin(Time.time * shakeSpeed));
	// 		blockRigidBody.MovePosition(targetPosition);
	// 		timeElapsed += Time.deltaTime;
	// 		yield return null;
	// 	}
	// 	blockRigidBody.MovePosition(startingPosition);
	// 	blockRigidBody.position = startingPosition;
	// }

	private IEnumerator BlocksDrop() {
		float timeElapsed = 0f;
		while (timeElapsed < animationTime) {
			blockRigidBody.MovePosition(transform.position - transform.up * animationSpeed * Time.deltaTime ); 
			timeElapsed += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}		
	}

	private IEnumerator BlocksHold() {
		yield return new WaitForSeconds(hiddenTime);
	}

	private IEnumerator BlocksReturn() {
		float timeElapsed = 0f;
		while (timeElapsed < animationTime) {
			blockRigidBody.MovePosition(transform.position + transform.up * animationSpeed * Time.deltaTime ); 
			timeElapsed += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
		blockRigidBody.position = startingPosition;
	}
}
