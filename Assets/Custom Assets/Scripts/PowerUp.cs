using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public int type;
	public Player target;
	
	private float minSpeed = 12.0f;
	private float accelSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		//type = 0;
		//target = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.magnitude < minSpeed && target != null) {
			Vector3 vel = target.transform.position - transform.position;
			vel = vel / vel.magnitude * accelSpeed * Time.deltaTime;
			rigidbody.AddForce (vel, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision Collection) {
		if (Collection.gameObject.name == "Player Left" || Collection.gameObject.name == "Player Right") {
			switch (type) {
			case 0:
				Collection.gameObject.GetComponent<Player>().increaseSize(0.25f);
				break;
				
			case 1:
				Collection.gameObject.GetComponent<Player>().increaseSize(0.5f);
				break;
				
			case 2:
				Collection.gameObject.GetComponent<Player>().increaseSize(-0.15f);
				break;
				
			case 3:
				Collection.gameObject.GetComponent<Player>().increaseSize(-0.35f);
				break;
			}
			
			Destroy(gameObject);
		} else if (Collection.gameObject.name == "Green_Goal" || Collection.gameObject.name == "Orange_Goal") {
			Destroy(gameObject);
		}
	}
}
