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
	public GameObject paddle;

	public Vector3 initialImpulse;
	public Vector3 dropLocation;
	public float height;
	public float dropSpeed;
	public float maxSpeed;
	public float minSpeed;
	public eBall ball;
<<<<<<< HEAD
	public float ballheight;
=======

>>>>>>> FETCH_HEAD
	Vector3 leftImpulse = new Vector3(-2,0,0);
	Vector3 rightImpulse = new Vector3(2,0,0);
	int normalBrickScore = 1;
	int goalBrickScore = 3;
	float goalPointPercentage = 0.20f;
	float friction = 0.6f;


	// Use this for initialization
	void Start () {
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (rigidbody.position.y < ballheight) {
			rigidbody.MovePosition(new Vector3(rigidbody.position.x, ballheight, rigidbody.position.z));
=======
		if (rigidbody.position.y < height) {
			rigidbody.MovePosition(new Vector3(rigidbody.position.x, height, rigidbody.position.z));
>>>>>>> FETCH_HEAD
			//rigidbody.AddForce(new Vector3(0, -rigidbody.velocity.y, 0), ForceMode.Impulse);
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			collider.isTrigger = false;
			score.GetComponent<Scores>().increaseMultiplier();
			rigidbody.AddForce(initialImpulse * score.GetComponent<Scores>().getMultiplier(), ForceMode.Impulse);
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
				rigidbody.AddForce(new Vector3(0, 0, friction * Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(new Vector3(0, 0, friction * Collection.gameObject.GetComponent<Player>().inputSpeed * 
				                               Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			} else if (Collection.gameObject.name == "Orange_Goal") {
				int points = (int)(otherScore.GetComponent<Scores>().getScore () * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
				otherScore.GetComponent<Scores>().RemoveLife();
				dropBall(dropLocation);
			} else if (Collection.gameObject.name == "Green_Goal") {
				int points = (int)(score.GetComponent<Scores>().getScore () * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(-1*points);
				score.GetComponent<Scores>().RemoveLife();
				dropBall(dropLocation);
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
				int points = (int)(otherScore.GetComponent<Scores>().getScore() * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(points);
				otherScore.GetComponent<Scores>().AddScore(-1*points);
				otherScore.GetComponent<Scores>().RemoveLife();
				dropBall(dropLocation);
			} else if (Collection.gameObject.name == "Orange_Goal") {
				int points = (int)(score.GetComponent<Scores>().getScore() * goalPointPercentage);
				score.GetComponent<Scores>().AddScore(-1*points);
				score.GetComponent<Scores>().RemoveLife();
				dropBall(dropLocation);
			}
		}
	}

	void dropBall(Vector3 location) {
		rigidbody.transform.position = location;
		rigidbody.constraints = RigidbodyConstraints.None;
		collider.isTrigger = true;
		rigidbody.AddForce(-rigidbody.velocity + new Vector3(0, dropSpeed, 0), ForceMode.Impulse);
	}
}
