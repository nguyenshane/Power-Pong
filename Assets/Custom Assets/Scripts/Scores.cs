using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {

	public GameObject number;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScore (int newScore) {
		score = newScore;
		number.guiText.text = score.ToString();
	}

	public void AddScore (int newScore) {
		score += newScore;
		number.guiText.text = score.ToString();
	}
}
