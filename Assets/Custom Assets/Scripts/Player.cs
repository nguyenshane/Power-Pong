using UnityEngine;
using System.Collections;

public enum ePlayer 
{
	Left,
	Right
}

public class Player : MonoBehaviour {

	public float speed = 15f;
	public float inputSpeed = 0f;
	public float maxSize;
	public float minSize;
	public float friction;
	public GameObject ball;
	public ePlayer player;
	

	void Start() {

	}

	// Update is called once per frame
	void Update () {
		if (player == ePlayer.Left) {
			inputSpeed = Input.GetAxisRaw("PlayerLeft");
		} else if (player == ePlayer.Right) {
			inputSpeed = Input.GetAxisRaw("PlayerRight");
		}

		transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
	}

	//Size should be > -1.0
	public void increaseSize(float size) {
		float newZScale = transform.localScale.z * (1.0f + size);
		if (newZScale > maxSize) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, maxSize);
		else if (newZScale < minSize) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, minSize);
		else transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZScale);
	}
}