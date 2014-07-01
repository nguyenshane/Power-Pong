using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private float gen;
	private float gen2;

	public bool canDropPowerup;

	// Use this for initialization
	void Start () {

		GameObject PowerupCtrl = GameObject.Find ("PowerupController");
		PowerupController pwrCtrl = PowerupCtrl.GetComponent <PowerupController> ();

		gen = Random.Range(1,24);
		gen2 = (gen/6)%1;
	
		//Debug.Log(gen2);

		if (gen2 == 0 && pwrCtrl.powerupsGenerated < pwrCtrl.numberOfPowerups) {
			canDropPowerup = true;
			pwrCtrl.powerupsGenerated +=1;
			Debug.Log(pwrCtrl.powerupsGenerated);
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
				//DROP POWERUP HERE
			} 
				//DONT DROP POWERUP
		
		}

	}



}
