using UnityEngine;
using System.Collections;

public enum eBall
{
	Left,
	Right
}

public class Ball : MonoBehaviour {

	public Vector3 initialImpulse;

	public eBall ball;
	Vector3 leftImpulse = new Vector3(-2,0,0);
	Vector3 rightImpulse = new Vector3(2,0,0);

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


			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
			}
			else if (Collection.gameObject.name == "Player Left") {
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);
			}
		} else if (ball == eBall.Right) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
				rigidbody.AddForce(rightImpulse, ForceMode.Impulse);

			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
			}
			else if (Collection.gameObject.name == "Player Right") {
				rigidbody.AddForce(leftImpulse, ForceMode.Impulse);
			}
		}
	}
}
