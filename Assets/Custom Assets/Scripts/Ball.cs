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
	float dropSpeed = -16f;
	float dropDistance = 48f;
	float maxSpeed = 30f;
	float minSpeed = 12f;
	float friction = 0.6f;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.position.y < 1.65f) {
			rigidbody.MovePosition(new Vector3(rigidbody.position.x, 1.65f, rigidbody.position.z));
			//rigidbody.AddForce(new Vector3(0, -rigidbody.velocity.y, 0), ForceMode.Impulse);
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
		}

		if (rigidbody.velocity.magnitude < minSpeed) {
			if (rigidbody.velocity.magnitude != 0) {
				rigidbody.AddForce(rigidbody.velocity * (1 - minSpeed / rigidbody.velocity.magnitude), ForceMode.Impulse);
			} else {
				rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
			}
		} else if (rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.AddForce(rigidbody.velocity * -1 * (1 - maxSpeed / rigidbody.velocity.magnitude), ForceMode.Impulse);
		}
	}


	void OnCollisionEnter(Collision Collection) {
		if (ball == eBall.Left) {
			if(Collection.gameObject.name == "Brick") {
				Destroy(Collection.gameObject);
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(normalBrickScore);
			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(goalBrickScore);
			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
			} else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Orange_Goal") {
				int points = (int)(otherScore.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
				otherScore.GetComponent<Scores>().RemoveLife();
				dropBall(-12f);
			} else if (Collection.gameObject.name == "Green_Goal") {
				int points = (int)(score.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(-1*points);
				score.GetComponent<Scores>().RemoveLife();
				dropBall(-12f);
			}
		} else if (ball == eBall.Right) {
			if(Collection.gameObject.name == "Brick") {
				Destroy(Collection.gameObject);
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(normalBrickScore);
			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(goalBrickScore);
			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
			} else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Green_Goal") {
				int points = (int)(otherScore.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
				otherScore.GetComponent<Scores>().RemoveLife();
				dropBall(12f);
			} else if (Collection.gameObject.name == "Orange_Goal") {
				int points = (int)(score.GetComponent<Scores>().score * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(-1*points);
				score.GetComponent<Scores>().RemoveLife();
				dropBall(12f);
			}
		}
	}

	void dropBall(float x) {
		rigidbody.transform.position = new Vector3(x, dropDistance, 0);
		rigidbody.constraints = RigidbodyConstraints.None;
		rigidbody.AddForce(-rigidbody.velocity + new Vector3(0, dropSpeed, 0), ForceMode.Impulse);
	}
}
