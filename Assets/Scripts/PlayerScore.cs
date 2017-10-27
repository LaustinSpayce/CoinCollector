using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public int score = 0;

	public Text scoreText;

	void Start () {
		UpdateScore();
	}
	
	void Update () {
		
	}

	public void AddPoints (int points) {
		score += points;
		UpdateScore();
	}

	private void UpdateScore () {
		scoreText.text = score.ToString();
	}
}
