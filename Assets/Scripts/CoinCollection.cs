using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour {

	public int coinValue = 0;

	// void OnTriggerEnter (Collider other) {
	// 	if (other.gameObject.layer == 9) {
	// 		var ScoreCommand = other.gameObject.GetComponent<PlayerScore>();
	// 		ScoreCommand.AddPoints(coinValue);
	// 		Destroy(this.gameObject);
	// }
	    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
	
// }

}
