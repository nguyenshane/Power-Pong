using UnityEngine;
using System.Collections;

public enum eBall
{
	Left,
	Right
}

public class Ball : MonoBehaviour {

	public GameObject score;
	public GameObject otherScore;

	public Vector3 initialImpulse;

	public eBall ball;
	Vector3 leftImpulse = new Vector3(-2,0,0);
	Vector3 rightImpulse = new Vector3(2,0,0);
	int normalBrickScore = 1;
	int goalBrickScore = 3;
	float goalPointPercentage = 0.20f;
	float maxSpeed = 20f;
	float minSpeed = 6f;
	float friction = 0.5f;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.magnitude < minSpeed) {
			rigidbody.AddForce (rigidbody.velocity * (1 - minSpeed / rigidbody.velocity.magnitude), ForceMode.Impulse);
		} else if (rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.AddForce (rigidbody.velocity * -1 * (1 - maxSpeed / rigidbody.velocity.magnitude), ForceMode.Impulse);
		}
	}


	void OnCollisionEnter(Collision Collection)
	{
		if (ball == eBall.Left) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(normalBrickScore);
			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(goalBrickScore);
			}
			else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			}
			else if (Collection.gameObject.name == "Orange_Goal") {
				int points = (int)(otherScore.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
			}
		} else if (ball == eBall.Right) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(normalBrickScore);
			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(goalBrickScore);
			}
			else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			}
			else if (Collection.gameObject.name == "Gtreen_Goal") {
				int points = (int)(otherScore.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
			}
		}

		/*
		//Minimum/Maximum speed restrictions for the ball
		if (Mathf.Abs(rigidbody.velocity.x) < minSpeed) {
			rigidbody.AddForce(new Vector3((minSpeed - Mathf.Abs(rigidbody.velocity.x)) * rigidbody.velocity.x / Mathf.Abs(rigidbody.velocity.x), 0, 0), ForceMode.Impulse);
		}
		else if (rigidbody.velocity.magnitude > maxSpeed) { //else keeps speed consistent between collisions that wouldn't otherwise affect speed
			rigidbody.AddForce(rigidbody.velocity * -1 * (maxSpeed / rigidbody.velocity.magnitude), ForceMode.Impulse);
		}
		*/

	}
}
