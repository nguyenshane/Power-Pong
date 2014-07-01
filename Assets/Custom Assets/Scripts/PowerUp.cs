using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public int type;

	// Use this for initialization
	void Start () {
		type = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision Collection) {
		if (Collection.gameObject.name == "Player Left" || Collection.gameObject.name == "Player Right") {
			//add powerup effects here
			Destroy(gameObject);
		}
	}
}
