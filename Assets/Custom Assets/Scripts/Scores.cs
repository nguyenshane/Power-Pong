using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {

	public GameObject scoreNumber;
	public GameObject livesNumber;

	public int score;
	public int lives;

	// Use this for initialization
	void Start () {
		score = 0;
		lives = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScore (int newScore) {
		score = newScore;
		scoreNumber.guiText.text = score.ToString();
	}

	public void AddScore (int newScore) {
		score += newScore;
		scoreNumber.guiText.text = score.ToString();
	}

	public void RemoveLife() {
		lives--;
		livesNumber.guiText.text = lives.ToString();
		
		if (lives <= 0) {
			//Continue to the next level
		}
	}
}
