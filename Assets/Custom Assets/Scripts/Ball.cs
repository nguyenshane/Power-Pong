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
			} else if (Collection.gameObject.name == "Brick_O") {
				Destroy(Collection.gameObject);
			}
		} else if (ball == eBall.Right) {
			if(Collection.gameObject.name == "Brick")
			{
				Destroy(Collection.gameObject);
			} else if (Collection.gameObject.name == "Brick_G") {
				Destroy(Collection.gameObject);
			}
		}
	}
}
