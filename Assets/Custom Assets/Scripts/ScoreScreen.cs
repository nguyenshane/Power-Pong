using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

	public int currentLevel;
	public int maxLevels;

	public int greenLives, orangeLives, greenScore, orangeScore, greenWins, orangeWins, greenTotalWins, orangeTotalWins;

	int padding = 24;
	int width = 120;
	bool showing;

	// Use this for initialization
	void Start () {
		greenLives = orangeLives = greenScore = orangeScore = greenWins = orangeWins = greenTotalWins = orangeTotalWins = 0;
		showing = false;
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		if (showing == true) {
			GUI.Box(new Rect(padding, padding, Screen.width - padding*2, Screen.height - padding*2), "Scores");

			GUI.Label(new Rect(Screen.width / 4, Screen.height / 4, width, 20), "Match Lives: ");
			GUI.Label(new Rect(Screen.width / 4 + width, Screen.height / 4, width, 20), greenLives.ToString() + " : " + orangeLives.ToString());

			GUI.Label(new Rect(Screen.width / 4, Screen.height / 4 + 40, width, 20), "Match Scores: ");
			GUI.Label(new Rect(Screen.width / 4 + width, Screen.height / 4 + 40, width, 20), greenScore.ToString() + " : " + orangeScore.ToString());

			GUI.Label(new Rect(Screen.width / 4, Screen.height / 4 + 80, width, 20), "Current Wins: ");
			GUI.Label(new Rect(Screen.width / 4 + width, Screen.height / 4 + 80, width, 20), greenWins.ToString() + " : " + orangeWins.ToString());

			GUI.Label(new Rect(Screen.width / 4, Screen.height / 4 + 120, width, 20), "Total Wins: ");
			GUI.Label(new Rect(Screen.width / 4 + width, Screen.height / 4 + 120, width, 20), greenTotalWins.ToString() + " : " + orangeTotalWins.ToString());

			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height - 60, 80, 20), "Continue")) {
				showing = false;
				Time.timeScale = 1;
				currentLevel++;
				if (greenWins >= 2) {
					greenTotalWins++;
					greenWins = 0;
					orangeWins = 0;
					currentLevel = 1;
				} else if (orangeWins >= 2) {
					orangeTotalWins++;
					greenWins = 0;
					orangeWins = 0;
					currentLevel = 1;
				}
				else if (currentLevel > maxLevels) {
					if (greenWins > orangeWins) {
						greenTotalWins++;
					} else orangeTotalWins++;

					greenWins = 0;
					orangeWins = 0;
					currentLevel = 1;
				}
				Application.LoadLevel(currentLevel);
			}
		}
	}
	
	public void activate() {
		Time.timeScale = 0;
		showing = true;
	}
}