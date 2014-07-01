﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private float gen;
	private float gen2;

	private float powerUpSpeed = 20f;

	public Transform PowerUpPrefab;
	public GameObject PowerupCtrl;

	public bool canDropPowerup;

	// Use this for initialization
	void Start () {

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
				PowerUp newPowerUp = ((Transform)Instantiate(PowerUpPrefab, transform.position, Quaternion.identity)).gameObject.GetComponent<PowerUp>();
				newPowerUp.type = Random.Range(0, 3);
				Vector3 vel = Collection.gameObject.GetComponent<Ball>().paddle.GetComponent<Player>().transform.position - transform.position;
				vel = vel / vel.magnitude * powerUpSpeed;
				newPowerUp.rigidbody.AddForce(vel, ForceMode.Impulse);
			} 
		}
	}
}
