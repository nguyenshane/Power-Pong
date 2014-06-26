using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 initialImpulse;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision Collection)
	{
		if(Collection.gameObject.name == "Brick")
		{
			Destroy(Collection.gameObject);
		}
	}
}
