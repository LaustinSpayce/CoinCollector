using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecter : MonoBehaviour {

	public int coinValue = 0;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			var ScoreCommand = other.gameObject.GetComponent<PlayerScore>();
			ScoreCommand.AddPoints(coinValue);
			Destroy(this.gameObject);
		}

	}
}
