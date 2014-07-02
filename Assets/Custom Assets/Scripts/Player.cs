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
	public ePlayer player;

	float currentSize;
	

	void Start() {
		currentSize = 3.0f;
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

	public void increaseSize(float size) {
		if (currentSize + size > maxSize) transform.localScale = new Vector3(transform.localScale.x, maxSize, transform.localScale.z);
		else if (currentSize + size < minSize) transform.localScale = new Vector3(transform.localScale.x, minSize, transform.localScale.z);
		else transform.localScale += new Vector3(0, size, 0);
	}
}