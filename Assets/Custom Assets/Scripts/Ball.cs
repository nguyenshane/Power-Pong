using UnityEngine;
using System.Collections;

public enum eBall
{
	Left,
	Right
}

public class Ball : MonoBehaviour {

	public GameObject score;

	public Vector3 initialImpulse;

	public eBall ball;
	Vector3 leftImpulse = new Vector3(-2,0,0);
	Vector3 rightImpulse = new Vector3(2,0,0);
	float friction = 0.5f;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter(Collision Collection)
	{
		if (ball == eBall.Left) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(2);
			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(3);
			}
			else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed*Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			}
		} else if (ball == eBall.Right) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
				score.GetComponent<Scores>().AddScore(2);
			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
				score.GetComponent<Scores>().AddScore(3);
			}
			else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
				rigidbody.AddForce(new Vector3(0, 0, friction*Collection.gameObject.GetComponent<Player>().inputSpeed*Collection.gameObject.GetComponent<Player>().speed), ForceMode.Impulse);
			}
		}
	}
}
