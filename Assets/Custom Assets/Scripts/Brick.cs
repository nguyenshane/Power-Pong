using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private float gen;
	private float gen2;
	public bool canDropPowerup;

	// Use this for initialization
	void Start () {
		gen = Random.Range(1,24);
		gen2 = (gen/6)%1;
		Debug.Log(gen);
		Debug.Log(gen2);
		if (gen2 == 0 ) {
			canDropPowerup = true;
		} else {
			canDropPowerup = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision Collection) {
		if(Collection.gameObject.name == "BallG" || Collection.gameObject.name == "BallO") {
			if (canDropPowerup) {
				Debug.Log("Dropped Powerup");
			} 
				Debug.Log("Nothing to Drop");
		
		}

	}



}
