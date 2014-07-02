using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {

	public GameObject scoreNumber;
	public GameObject livesNumber;

	public float goalSpeedMultiplier;
	public int maxLives;
	private float currentMultiplier;
	private int score;
	private int lives;


	// Use this for initialization
	void Start () {
		score = 0;
		lives = maxLives;
		currentMultiplier = 1;
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
			Application.LoadLevel("lEVEL2");
		}
	}

	public int getLives() {
		return lives;
	}

	public int getScore() {
		return score;
	}

	public float getMultiplier() {
		return currentMultiplier;
	}

	public void increaseMultiplier() {
		currentMultiplier += goalSpeedMultiplier;
	}
}
